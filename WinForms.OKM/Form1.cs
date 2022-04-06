using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private const int n = 10000;
        private vect[] Tr = new vect[n];
        private double[] Vt = new double[n];
        private int iter = 0;
        private int i1 = 0;
        private vect gravity;
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



        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Timer ChartTimer;

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
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
            MainTimer.Stop();
            ChartTimer.Stop();
        }
        private void Verle(Object source, EventArgs e)
        {
            iter++;
            if (hight <= 0) return;
            vect acceleration = GetAcceleration(speed);
            r += dt * speed + 0.5 * dt * dt * acceleration;
            hight = r.y;

            vect predictor = speed + dt * acceleration;

            speed += 0.5 * dt * acceleration;
            acceleration = GetAcceleration(predictor);
            speed += 0.5 * dt * acceleration;

            Tr[iter] = r;
            Vt[iter] = speed.Mod;
            if (hight < 0) Reset();
        }
        private void Reset()
        {
            MainTimer.Stop();
            iter = 0;
            ButtonStart.Enabled = true;
        }
        private void ChartReset()
        {
            ChartTr.Series[0].Points.Clear();
            ChartTr.Series[1].Points.Clear();
            ChartTr.Series[0].Points.Clear();
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
            bool check = System.Double.TryParse(textHight.Text, out hight);
            if (!check || hight < 0)
            {
                MessageBox.Show("Некорректна начальная высота");
                res = false;
            }

            double angle;
            check = System.Double.TryParse(textAngle.Text, out angle);
            if (!check || !(angle > 0 && angle <= 90))
            {
                MessageBox.Show("Некорректен угол");
                res = false;
            }
            double speedMax;
            check = System.Double.TryParse(textSpeedMax.Text, out speedMax);
            if (!check || speedMax < 0)
            {
                MessageBox.Show("Некорректна максимальная скорость");
                res = false;
            }
            double speed;
            check = System.Double.TryParse(textSpeed.Text, out speed);
            if (!check || speed < 0)
            {
                MessageBox.Show("Некорректна начальная скорость");
                res = false;
            }
            double speedWind;
            check = System.Double.TryParse(textSpeedWind.Text, out speedWind);
            if (!check)
            {
                MessageBox.Show("Некорректна начальная скорость");
                res = false;
            }
            double dt;
            check = System.Double.TryParse(textDt.Text, out dt);
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
                this.speed = new vect(speed * Math.Cos(angle), speed * Math.Sin(angle), 0);
                this.r = new vect(0, hight, 0);
                this.gravity = new vect(0, -9.81, 0);
                Tr[0] = new vect(0, hight, 0);
                Vt[0] = speed;
            }
            return res;
        }
        private void Visualize(object source, EventArgs e)
        {
            for (int i = i1; i < iter; i++)
            {
                if (hight < 0)
                {
                    ChartTimer.Stop();
                    i1 = 0;
                    return;
                }

             ChartTr.Series[2].Points.AddXY(i + dt, Vt[i]);
             ChartTr.Series[1].Points.AddXY(i + dt, Tr[i].x);
             ChartTr.Series[0].Points.AddXY(i + dt, Tr[i].y);
            }
            i1 = iter;
        }
        private void SetTimers()
        {
            MainTimer = new System.Windows.Forms.Timer();
            MainTimer.Tick += new EventHandler(Verle);

            MainTimer.Start();

            ChartTimer = new System.Windows.Forms.Timer();
            ChartTimer.Tick += new EventHandler(Visualize);
            ChartTimer.Start();
        }
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            textHight.Text = "";
            textAngle.Text = "";
            textSpeedMax.Text = "";
            textSpeed.Text = "";
            textSpeedWind.Text = "";
            textDt.Text = "";
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

