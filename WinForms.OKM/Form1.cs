using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OKM
{
    public partial class Form1 : Form
    {
        private double hight;
        private double speedMax;
        private double dt;
        private vect speedWind;
        private vect speed;
        private vect r;
        private int iter = 0;
        private vect gravity;

        private Queue<vect> Tr_buffer = new Queue<vect>();
        private Queue<double> Vt_buffer = new Queue<double>();

        public Form1()
        {
            InitializeComponent();
            textHight.Text = "30";
            textAngle.Text = "45";
            textSpeedMax.Text = "120";
            textSpeed.Text = "60";
            textSpeedWind.Text = "0";
            textDt.Text = "0,1";
        }


        private Timer MainTimer;
        private Timer ChartTimer;

        private void Verle(Object source, EventArgs e)
        {
            iter++;
            vect acceleration = GetAcceleration(speed);
            r += dt * speed + 0.5 * dt * dt * acceleration;
            hight = r.y;

            vect predictor = speed + dt * acceleration;

            speed += 0.5 * dt * acceleration;
            acceleration = GetAcceleration(predictor);
            speed += 0.5 * dt * acceleration;

            Tr_buffer.Enqueue(r);
            Vt_buffer.Enqueue(speed.Mod);
            if (hight < 0)
                Reset();
        }

        private void Reset()
        {
            MainTimer.Stop();
            ButtonStart.Enabled = true;
        }

        private void ChartReset()
        {
            ChartTr.Series[0].Points.Clear();
            ChartTr.Series[1].Points.Clear();
            ChartTr.Series[2].Points.Clear();
        }

        private vect GetAcceleration(vect speed)
        {
            vect velocity = speed - speedWind;
            return gravity - Math.Exp(-hight / 10000) * gravity.Mod * velocity.Mod / (speedMax * speedMax) * velocity;
        }

        private bool ValidateInput()
        {
            bool res = true;

            double hight;
            bool check = Double.TryParse(textHight.Text, out hight);
            if (!check || hight < 0)
            {
                MessageBox.Show("Некорректна начальная высота");
                res = false;
            }

            double angle;
            check = Double.TryParse(textAngle.Text, out angle);
            if (!check || !(angle >= -90 && angle <= 90))
            {
                MessageBox.Show("Некорректен угол");
                res = false;
            }

            double speedMax;
            check = Double.TryParse(textSpeedMax.Text, out speedMax);
            if (!check || speedMax < 0)
            {
                MessageBox.Show("Некорректна максимальная скорость");
                res = false;
            }

            double speed;
            check = Double.TryParse(textSpeed.Text, out speed);
            if (!check || speed < 0)
            {
                MessageBox.Show("Некорректна начальная скорость");
                res = false;
            }

            double speedWind;
            check = Double.TryParse(textSpeedWind.Text, out speedWind);
            if (!check)
            {
                MessageBox.Show("Некорректна начальная скорость");
                res = false;
            }

            double dt;
            check = Double.TryParse(textDt.Text, out dt);
            if (!check || dt <= 0)
            {
                MessageBox.Show("Некорректен шаг интегрирования");
                res = false;
            }

            if (res)
            {
                this.hight = hight;
                this.dt = dt;
                this.speedMax = speedMax;
                this.speedWind = new vect(speedWind, 0, 0);
                this.speed = new vect(speed * Math.Cos(angle / 180 * Math.PI), speed * Math.Sin(angle / 180 * Math.PI),
                    0);
                this.r = new vect(0, hight, 0);
                this.gravity = new vect(0, -9.81, 0);
                Tr_buffer.Enqueue(new vect(0, hight, 0));
                Vt_buffer.Enqueue(speed);
            }

            return res;
        }

        private void Visualize(object source, EventArgs e)
        {
            while (Tr_buffer.Count > 0)
            {
                ChartTr.Series[2].Points.AddXY(iter + dt, Vt_buffer.Dequeue());
                vect Tr = Tr_buffer.Dequeue();
                ChartTr.Series[1].Points.AddXY(iter + dt, Tr.x);
                ChartTr.Series[0].Points.AddXY(iter + dt, Tr.y);
            }

            if (!MainTimer.Enabled)
            {
                ChartTimer.Stop();
            }
        }

        private void SetTimers()
        {
            MainTimer = new Timer();
            MainTimer.Tick += Verle;

            MainTimer.Start();

            ChartTimer = new Timer();
            ChartTimer.Tick += Visualize;
            ChartTimer.Start();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            ChartReset();
            SetTimers();
            ChartTimer.Start();
            ButtonStart.Enabled = false;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            MainTimer.Stop();
            ChartTimer.Stop();
        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            MainTimer.Start();
            ChartTimer.Start();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ChartReset();
            Reset();
        }
    }
}


public struct vect
{
    public double x, y, z;

    public double modul()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

    public double Mod
    {
        get { return Math.Sqrt(x * x + y * y + z * z); }
    }

    public vect(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static vect operator +(vect a, vect b)
    {
        vect c = new vect();
        c.x = a.x + b.x;
        c.y = a.y + b.y;
        return c;
    }

    public static double operator *(vect a, vect b)
    {
        return a.x * b.x + a.y * b.y;
    }

    public static vect operator *(double c, vect a)
    {
        vect h = new vect();
        h.x = a.x * c;
        h.y = a.y * c;
        return h;
    }

    public static vect operator *(vect a, double c)
    {
        vect h = new vect();
        h.x = a.x * c;
        h.y = a.y * c;
        return h;
    }

    public static vect operator -(vect a, vect b)
    {
        vect c = new vect();
        c.x = a.x - b.x;
        c.y = a.y - b.y;
        return c;
    }

    public static vect operator &(vect a, vect b)
    {
        vect c = new vect();
        c.x = a.y * b.z - a.z * b.y;
        c.x = a.z * b.y - a.y * b.z;
        c.x = a.x * b.z - a.z * b.x;
        return c;
    }
}