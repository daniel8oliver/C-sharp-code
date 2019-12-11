using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        private Thread _captureThread;
        SerialPort arduinoSerial = new SerialPort();
        bool enableCoordinateSending = true;
        Thread serialMonitoringThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // create the capture object and processing thread
            _capture = new VideoCapture(1);
            _captureThread = new Thread(ProcessImage);
            _captureThread.Start();

            try
            {
                arduinoSerial.PortName = "COM7";
                arduinoSerial.BaudRate = 115200;
                arduinoSerial.Open();
                serialMonitoringThread = new Thread(MonitorSerialData);
                serialMonitoringThread.Start();
                xInput.Text = "130";
                yInput.Text = "224";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Initializing COM port");
                Close();
            }
        }
        private void ProcessImage()
        {
            while (_capture.IsOpened)
            {

                {
                    Mat workingImage = _capture.QueryFrame();
                    // resize to PictureBox aspect ratio
                    int newHeight = (workingImage.Size.Height * pictureBoxSource.Size.Width) / workingImage.Size.Width;
                    Size newSize = new Size(pictureBoxSource.Size.Width, newHeight);
                    CvInvoke.Resize(workingImage, workingImage, newSize);
                    // as a test for comparison, create a copy of the image with a binary filter:
                    var binaryImage = workingImage.ToImage<Gray, byte>().ThresholdBinary(new Gray(125), new
                    Gray(255)).Mat;
                    // Sample for gaussian blur:
                    var blurredImage = new Mat();
                    var cannyImage = new Mat();
                    var decoratedImage = new Mat();
                    CvInvoke.GaussianBlur(workingImage, blurredImage, new Size(9, 9), 0);
                    // convert to B/W
                    CvInvoke.CvtColor(blurredImage, blurredImage, typeof(Bgr), typeof(Gray));
                    // apply canny:
                    // NOTE: Canny function can frequently create duplicate lines on the same shape
                    // depending on blur amount and threshold values, some tweaking might be needed.
                    // You might also find that not using Canny and instead using FindContours on
                    // a binary-threshold image is more accurate.
                    CvInvoke.Canny(blurredImage, cannyImage, 150, 255);
                    // make a copy of the canny image, convert it to color for decorating:
                    CvInvoke.CvtColor(cannyImage, decoratedImage, typeof(Gray), typeof(Bgr));
                    // find contours:
                    using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                    {
                        // Build list of contours
                        CvInvoke.FindContours(cannyImage, contours, null, RetrType.List,
                        ChainApproxMethod.ChainApproxSimple);
                        string detShape = "";
                        for (int i = 0; i < contours.Size; i++)
                        {
                            VectorOfPoint contour = contours[i];

                            double shapeType = 0;
                            using (VectorOfPoint approxContour = new VectorOfPoint())
                            {
                                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                                if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                                {
                                    if (approxContour.Size == 3)
                                    {
                                        detShape = "Triangle";
                                        shapeType = 3;
                                        //Invoke(new Action(() => { shapesLabel.Text = "Triangle"; }));
                                        CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Green).MCvScalar);
                                    }

                                    else if (approxContour.Size == 4)
                                    {
                                        detShape = "Square";
                                        shapeType = 4;
                                        //Invoke(new Action(() => { shapesLabel.Text = "Square"; }));
                                        CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Red).MCvScalar);
                                    }
                                    //CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Green).MCvScalar);

                                    Rectangle boundingBox = CvInvoke.BoundingRectangle(contour);
                                    MarkDetectedObject(workingImage, contours[i], boundingBox, CvInvoke.ContourArea(contour), detShape);
                                    // CvInvoke.Rectangle(decoratedImage, boundingBox, new Bgr(Color.Blue).MCvScalar);
                                    Point center = new Point(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height / 2);
                                    CvInvoke.Circle(decoratedImage, center, 2, new Bgr(Color.Yellow).MCvScalar);
                                }
                                Invoke(new Action(() => { contourLabel.Text = $" There are {contours.Size} contours detected"; }));

                            }

                            if(enableCoordinateSending)
                            {
                                double angle1 = 0;
                                double angle2 = 0;
                                double angle3 = 0;
                               


                                sendCoord(angle1,angle2,angle3, shapeType);
                            }
                            // output images:
                            pictureBoxSource.Image = workingImage.Bitmap;
                            pictureBoxContour.Image = decoratedImage.Bitmap;
                            Thread.Sleep(100);
                        }
                    }
                }
            }
        }

        private void MarkDetectedObject(Mat frame, VectorOfPoint contour, Rectangle boundingBox, double area, string shape1)
        {
            // Drawing contour and box around it
            CvInvoke.Polylines(frame, contour, true, new Bgr(Color.Blue).MCvScalar);
            CvInvoke.Rectangle(frame, boundingBox, new Bgr(Color.Blue).MCvScalar);
            // Write information next to marked object
            Point center = new Point(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height / 2);
            var info = new string[] {
                                        $"Area: {area}",
                                        $"Position: {center.X}, {center.Y}",
                                        $"Shape: {shape1}"
                                        };
            //WriteMultilineText(frame, info, new Point(center.X, boundingBox.Bottom + 12));
            Invoke(new Action(() => { centersLabel.Text = $"The coordinates of center are: X: {center.X} and  Y: {center.Y}"; }));
        }
        //private static void WriteMultilineText(Mat frame, string[] lines, Point origin)
        //{
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        int y = i * 10 + origin.Y; // Moving down on each line
        //        CvInvoke.PutText(frame, lines[i], new Point(origin.X, y),
        //        FontFace.HersheyPlain, 0.8, new Bgr(Color.Blue).MCvScalar);
        //    }
        //}

        private void sendCoord (double angle1, double angle2, double angle3, double shape)
        {
            
            
           
                byte[] buffer = new byte[6] {
Encoding.ASCII.GetBytes("<")[0],
Convert.ToByte(angle1),
Convert.ToByte(angle2),
Convert.ToByte(angle3),
Convert.ToByte(shape),
Encoding.ASCII.GetBytes(">")[0]
};
                //arduinoSerial.Write(buffer, 0, 6);
            
           
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!enableCoordinateSending)
            {
                MessageBox.Show("Temporarily locked...");
                return;
            }
            int x = -1;
            int y = -1;
            if (int.TryParse(xInput.Text, out x) && int.TryParse(yInput.Text, out y))
            {
                byte[] buffer = new byte[4] {
Encoding.ASCII.GetBytes("<")[0],
Convert.ToByte(x),
Convert.ToByte(y),
Encoding.ASCII.GetBytes(">")[0]
};
                arduinoSerial.Write(buffer, 0, 4);
            }
            else
            {
                MessageBox.Show("X and Y values must be integers", "Unable to parse coordinates");
            }
        }
        private void MonitorSerialData()
        {
            while (true)
            {
                // block until \n character is received, extract command data
                string msg = arduinoSerial.ReadLine();
                // confirm the string has both < and > characters
                if (msg.IndexOf("<") == -1 || msg.IndexOf(">") == -1)
                {
                    continue;
                }
                // remove everything before the < character
                msg = msg.Substring(msg.IndexOf("<") + 1);
                // remove everything after the > character
                msg = msg.Remove(msg.IndexOf(">"));
                // if the resulting string is empty, disregard and move on
                if (msg.Length == 0)
                {
                    continue;
                }
                // parse the command
                if (msg.Substring(0, 1) == "S")
                {
                    enableCoordinateSending = false;
                    //// command is to suspend, toggle states accordingly:
                    //ToggleFieldAvailability(msg.Substring(1, 1) == "1");
                }
                else if (msg.Substring(0, 1) == "P")
                {
                    enableCoordinateSending = true;
                    //// command is to display the point data, output to the text field:
                    //Invoke(new Action(() =>
                    //{
                    //    returnedPointLbl.Text = $"Returned Point Data: {msg.Substring(1)}";
                    //}));
                }
            }
        }
        private void ToggleFieldAvailability(bool suspend)
        {
            Invoke(new Action(() =>
            {
                enableCoordinateSending = !suspend;
                toolStripLabel1.Text = $"State: {(suspend ? "Locked" : "Unlocked")}";
            }));
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _captureThread.Abort();
        }
    }
}
