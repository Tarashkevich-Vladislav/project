
namespace OKM
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.ButtonContinue = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.Hight = new System.Windows.Forms.Label();
            this.SpeedMax = new System.Windows.Forms.Label();
            this.SpeedWind = new System.Windows.Forms.Label();
            this.Angle = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.Dt = new System.Windows.Forms.Label();
            this.textHight = new System.Windows.Forms.TextBox();
            this.textSpeedMax = new System.Windows.Forms.TextBox();
            this.textSpeedWind = new System.Windows.Forms.TextBox();
            this.textAngle = new System.Windows.Forms.TextBox();
            this.textSpeed = new System.Windows.Forms.TextBox();
            this.textDt = new System.Windows.Forms.TextBox();
            this.ChartTr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ChartTr)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(12, 348);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Пуск";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(93, 348);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 1;
            this.ButtonStop.Text = "Стоп";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonContinue
            // 
            this.ButtonContinue.Location = new System.Drawing.Point(174, 348);
            this.ButtonContinue.Name = "ButtonContinue";
            this.ButtonContinue.Size = new System.Drawing.Size(75, 23);
            this.ButtonContinue.TabIndex = 2;
            this.ButtonContinue.Text = "Продолжить";
            this.ButtonContinue.UseVisualStyleBackColor = true;
            this.ButtonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(255, 348);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 3;
            this.ButtonReset.Text = "Сброс";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // Hight
            // 
            this.Hight.AutoSize = true;
            this.Hight.Location = new System.Drawing.Point(12, 30);
            this.Hight.Name = "Hight";
            this.Hight.Size = new System.Drawing.Size(102, 13);
            this.Hight.TabIndex = 4;
            this.Hight.Text = "Начальная высота";
            // 
            // SpeedMax
            // 
            this.SpeedMax.AutoSize = true;
            this.SpeedMax.Location = new System.Drawing.Point(12, 56);
            this.SpeedMax.Name = "SpeedMax";
            this.SpeedMax.Size = new System.Drawing.Size(134, 13);
            this.SpeedMax.TabIndex = 5;
            this.SpeedMax.Text = "Максимальная скорость";
            // 
            // SpeedWind
            // 
            this.SpeedWind.AutoSize = true;
            this.SpeedWind.Location = new System.Drawing.Point(12, 84);
            this.SpeedWind.Name = "SpeedWind";
            this.SpeedWind.Size = new System.Drawing.Size(87, 13);
            this.SpeedWind.TabIndex = 6;
            this.SpeedWind.Text = "Скорость ветра";
            // 
            // Angle
            // 
            this.Angle.AutoSize = true;
            this.Angle.Location = new System.Drawing.Point(12, 108);
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(72, 13);
            this.Angle.TabIndex = 7;
            this.Angle.Text = "Угол вылета";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Location = new System.Drawing.Point(12, 138);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(112, 13);
            this.Speed.TabIndex = 8;
            this.Speed.Text = "Начальная скорость";
            // 
            // Dt
            // 
            this.Dt.AutoSize = true;
            this.Dt.Location = new System.Drawing.Point(12, 165);
            this.Dt.Name = "Dt";
            this.Dt.Size = new System.Drawing.Size(112, 13);
            this.Dt.TabIndex = 9;
            this.Dt.Text = "Шаг интегрирования";
            // 
            // textHight
            // 
            this.textHight.Location = new System.Drawing.Point(137, 30);
            this.textHight.Name = "textHight";
            this.textHight.Size = new System.Drawing.Size(100, 20);
            this.textHight.TabIndex = 10;
            // 
            // textSpeedMax
            // 
            this.textSpeedMax.Location = new System.Drawing.Point(137, 56);
            this.textSpeedMax.Name = "textSpeedMax";
            this.textSpeedMax.Size = new System.Drawing.Size(100, 20);
            this.textSpeedMax.TabIndex = 11;
            // 
            // textSpeedWind
            // 
            this.textSpeedWind.Location = new System.Drawing.Point(137, 84);
            this.textSpeedWind.Name = "textSpeedWind";
            this.textSpeedWind.Size = new System.Drawing.Size(100, 20);
            this.textSpeedWind.TabIndex = 12;
            // 
            // textAngle
            // 
            this.textAngle.Location = new System.Drawing.Point(137, 110);
            this.textAngle.Name = "textAngle";
            this.textAngle.Size = new System.Drawing.Size(100, 20);
            this.textAngle.TabIndex = 13;
            // 
            // textSpeed
            // 
            this.textSpeed.Location = new System.Drawing.Point(137, 138);
            this.textSpeed.Name = "textSpeed";
            this.textSpeed.Size = new System.Drawing.Size(100, 20);
            this.textSpeed.TabIndex = 14;
            // 
            // textDt
            // 
            this.textDt.Location = new System.Drawing.Point(137, 165);
            this.textDt.Name = "textDt";
            this.textDt.Size = new System.Drawing.Size(100, 20);
            this.textDt.TabIndex = 15;
            // 
            // ChartTr
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartTr.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartTr.Legends.Add(legend1);
            this.ChartTr.Location = new System.Drawing.Point(313, 12);
            this.ChartTr.Name = "ChartTr";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Высота";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Дальность";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Скорость";
            this.ChartTr.Series.Add(series1);
            this.ChartTr.Series.Add(series2);
            this.ChartTr.Series.Add(series3);
            this.ChartTr.Size = new System.Drawing.Size(422, 300);
            this.ChartTr.TabIndex = 1;
            this.ChartTr.Text = "ChartTr";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChartTr);
            this.Controls.Add(this.textDt);
            this.Controls.Add(this.textSpeed);
            this.Controls.Add(this.textAngle);
            this.Controls.Add(this.textSpeedWind);
            this.Controls.Add(this.textSpeedMax);
            this.Controls.Add(this.textHight);
            this.Controls.Add(this.Dt);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Angle);
            this.Controls.Add(this.SpeedWind);
            this.Controls.Add(this.SpeedMax);
            this.Controls.Add(this.Hight);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonContinue);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.ButtonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ChartTr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.Button ButtonContinue;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Label Hight;
        private System.Windows.Forms.Label SpeedMax;
        private System.Windows.Forms.Label SpeedWind;
        private System.Windows.Forms.Label Angle;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label Dt;
        private System.Windows.Forms.TextBox textHight;
        private System.Windows.Forms.TextBox textSpeedMax;
        private System.Windows.Forms.TextBox textSpeedWind;
        private System.Windows.Forms.TextBox textAngle;
        private System.Windows.Forms.TextBox textSpeed;
        private System.Windows.Forms.TextBox textDt;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartTr;
    }
}

