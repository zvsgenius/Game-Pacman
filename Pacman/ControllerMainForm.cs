using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Pacman
{
    delegate void Invoker();

    public partial class ControllerMainForm : Form
    {

        Thread modelPlay;

        Model model;

        View view;

        const int fieldSize = 520;
        const int amountGhosts = 4;
        const int speedGame = 10;
        const int sizeObjects = 40;
        const int sizeDots = 6;

        int level, lives;

        #region Текстовая константа textAbout

        static string textAbout = "Игра:    \t\t\"Pacman\"" + Environment.NewLine +
                                          "Разработчик: \tВоробьев Александр" + Environment.NewLine + Environment.NewLine +

                                          "Цель игры:" + Environment.NewLine +
                                                           "\t\tДля победы нужно собрать все точки во" + Environment.NewLine +
                                                            "\t\tвсех уровнях игры." + Environment.NewLine + Environment.NewLine +

                                          "Управление:" + Environment.NewLine +
                                                           "\t\tНаправление движения пакмена изменяется " + Environment.NewLine +
                                                           "\t\tклавишами навигации - стрелками." + Environment.NewLine + Environment.NewLine +

                                          "Условия игры:" + Environment.NewLine +
                                                             "\t\tСтолкновения с приведениями отнимает" + Environment.NewLine +
                                                              "\t\tжизни. Игра заканчивается после потери" + Environment.NewLine +
                                                              "\t\tтрёх жизней.";

        #endregion Текстовые константы

        public ControllerMainForm()
        {
            InitializeComponent();

            ResetIndicators();          // Установка значений уровня игры и жизней пакмена на начальные

            CreateLevel();
        }

        void ResetIndicators()          // Установка значений уровня игры и жизней пакмена на начальные
        {
            level = 1;                  // Начальный уровень
            ChangePictureLevel();

            lives = 3;                  // Начальное количество жизней пакмена
            ChangePictureLives();

            toolStripStatusLabel1.ForeColor = Color.Green;
            toolStripStatusLabel1.Text = "Для запуска игры нажмите кнопку 'Старт'";
        }

        void CreateLevel()          // Создание экземпляра модели игры
        {

            model = new Model(fieldSize, amountGhosts, speedGame, sizeObjects, sizeDots, level, lives);
            view = new View(model);
            Controls.Add(view);
            model.changeStreep += new STREEP(ChangerStatusGame);
        }

        void RestartModel()       //Перезапуск экземпляра модели
        {
            Controls.Remove(view);
            CreateLevel();
        }

        void ChangerStatusGame()                    //Изменения статуса игры
        {
            Invoke(new Invoker(ChangeStageGame));

        }

        void ChangeStageGame()                   //Изменения стадий игры
        {
            if (model.gameStatus == GameStatus.winner)
                NextLevel();

            if (model.gameStatus == GameStatus.losing)
                PacmanDied();
        }

        void NextLevel()
        {
            if (level < 3)
            {
                level++;
                ChangePictureLevel();

                toolStripStatusLabel1.ForeColor = Color.Green;
                toolStripStatusLabel1.Text = "Уровень пройден! Для продолжения игры нажмите кнопку 'Старт'";

                Thread.Sleep(300);
                RestartModel();
            }
            else
            {
                level++;
                toolStripStatusLabel1.ForeColor = Color.Green;
                toolStripStatusLabel1.Text = "Вы выиграли!!!";
                StartPause_btn.Text = "Новая игра";
            }
        }

        void PacmanDied()
        {
            lives--;
            ChangePictureLives();
            Thread.Sleep(1000);

            if (lives > 0)
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Вы потеряли одну жизнь. Для продолжения игры нажмите кнопку 'Старт'";

                RestartModel();
            }
            else
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Вы проиграли!!! Для запуска новой игры нажмите кнопку 'Новая игра'";

                StartPause_btn.Text = "Новая игра";
            }
        }

        #region Отображение жизней и уровня

        void ChangePictureLives()       // Изменить на экране значение количества жизней пакмена
        {
            if (lives == 3)
            {
                pictureBoxLives1.Visible = true;
                pictureBoxLives2.Visible = true;
                pictureBoxLives3.Visible = true;
            }
            else if (lives == 2)
                pictureBoxLives3.Visible = false;
            else if (lives == 1)
                pictureBoxLives2.Visible = false;
            else if (lives == 0)
                pictureBoxLives1.Visible = false;

        }

        void ChangePictureLevel()           // Изменить на экране значение уровня игры
        {
            pictureBoxLevel1.Text = level.ToString();
        }

        #endregion Отображение жизней и уровня

        #region Запуск, остановка и презапуск игры

        void StopGame()
        {
            model.gameStatus = GameStatus.stoping;
            modelPlay.Abort();
            toolStripStatusLabel1.ForeColor = Color.Green;
            toolStripStatusLabel1.Text = "Игра остановлена. Для продолжения игры нажмите кнопку 'Старт'";
        }

        void StartGame()
        {
            model.gameStatus = GameStatus.playing;
            modelPlay = new Thread(model.Play);
            modelPlay.Start();
            toolStripStatusLabel1.ForeColor = Color.Black;
            toolStripStatusLabel1.Text = "Идёт игра...";
            view.Invalidate();
        }

        void ResetGame()
        {
            if (model.gameStatus == GameStatus.playing)
                StopGame();

            ResetIndicators();
            RestartModel();
        }

        #endregion Запуск, остановка и презапуск игры

        void ControllerMainForm_FormClosing(object sender, FormClosingEventArgs e)     // Обработка события закрытия приложения
        {
            if(model.gameStatus == GameStatus.playing)
            {
                StopGame();
            }

            DialogResult dr = MessageBox.Show("Вы действительно хотите выйти из игры?", "Pacman", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        #region Обработчики действий с кнопкой Старт / Пауза

        void StartPause_btn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        void StartPause_btn_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "Up": { model.WantPacmanDirect_x = 0; model.WantPacmanDirect_y = -1; } break;
                case "Down": { model.WantPacmanDirect_x = 0; model.WantPacmanDirect_y = 1; } break;
                case "Left": { model.WantPacmanDirect_x = -1; model.WantPacmanDirect_y = 0; } break;
                case "Right": { model.WantPacmanDirect_x = 1; model.WantPacmanDirect_y = 0; } break;
            }
        }

        void StartPause_btn_Click(object sender, EventArgs e)
        {
            if (lives == 0 || level == 4)
            {
                ResetGame();
                StartPause_btn.Text = "Старт / Пауза";
                return;
            }

            if (model.gameStatus == GameStatus.playing || model.gameStatus == GameStatus.stoping)
            {
                if (model.gameStatus == GameStatus.playing)
                    StopGame();
                else
                    StartGame();
            }
        }

        #endregion Обработчики действий с кнопкой Старт / Пауза

        #region Обработчики нажатия пунктов меню

        void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textAbout, "Pacman", MessageBoxButtons.OK,
                                  MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        #endregion Обработчики нажатия пунктов меню

    }
}
