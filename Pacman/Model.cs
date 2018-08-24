using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pacman
{
    public delegate void STREEP();

    class Model
    {
        public event STREEP changeStreep;

        public GameStatus gameStatus;                   // Перечисление статусов игры

        int fieldSize, amountGhostsInLevel, speedGame, sizeObjects, sizeDots;       // Переменные, управляющие моделью
        int testP_x, testP_y, tempP_D_x, tempP_D_y;        // Переменные для проверки возможности движения пакмена
        int wantPacmanDirect_x, wantPacmanDirect_y;       // Переменные для ручного управления пакменом
        int takenDots;                                  // Счётчик собранных точек
        int level, lives;                                // Информация об уровне и жизнях

        int[,] tempMatrix;                            // Временная матрица - эквивалент игрового поля. Используется для расстановки сущностей.
        int s;                              // Размерность игрового поля в ячейках временной матрицы

        List<Wall> walls;
        List<Dot> dots;
        Pacman pacman;
        List<Ghost> ghosts;

        Random r, r2;

        #region Свойста доступа к переменным модели

        internal List<Wall> Walls
        {
            get
            {
                return walls;
            }
        }

        internal List<Dot> Dots
        {
            get
            {
                return dots;
            }
        }

        internal int SpeedGame
        {
            get
            {
                return speedGame;
            }
        }

        internal Pacman Pacman
        {
            get
            {
                return pacman;
            }

        }

        internal List<Ghost> Ghosts
        {
            get
            {
                return ghosts;
            }
        }

        internal int WantPacmanDirect_x
        {
            set
            {
                if (value >= -1 && value <= 1)
                    wantPacmanDirect_x = value;
                else
                    wantPacmanDirect_x = 0;
            }
        }

        internal int WantPacmanDirect_y
        {
            set
            {
                if (value >= -1 && value <= 1)
                    wantPacmanDirect_y = value;
                else
                    wantPacmanDirect_y = 0;
            }
        }

        #endregion Свойста доступа к переменным модели


        public Model(int fieldSize, int amountGhosts, int speedGame, int sizeObjects, int sizeDots, int level, int lives)
        {

            this.fieldSize = fieldSize;  this.speedGame = speedGame; this.sizeObjects = sizeObjects; this.sizeDots = sizeDots; this.level = level; this.lives = lives;

            amountGhostsInLevel = amountGhosts + level - 1; 
                       
            r = new Random();
            r2 = new Random();

            CreateGame();

        }

        void CreateGame()                  // Обнуление всех показателей игры
        {
            gameStatus = GameStatus.stoping;

            walls = new List<Wall>();
            dots = new List<Dot>();
            ghosts = new List<Ghost>();

            s = fieldSize / sizeObjects;
            tempMatrix = new int[s, s];

            testP_x = testP_y = tempP_D_x = tempP_D_y = wantPacmanDirect_x = wantPacmanDirect_y = 0;        // Триггеры направления движения пакмена

            takenDots = 0;                  // Счётчик собранных точек

            CreatePacman(260, 420);        // Создание пакмена с указанием точки старта вручную

            CreateWalls();                   // Создание стен

            CreateDots();                   // Создание точек

            CreateGhosts();                   // Создание приведений
        }

        #region Методы создания сущностей на игровом поле
                
        void CreatePacman(int x_pacman, int y_pacman)
        {
            pacman = new Pacman(x_pacman, y_pacman, sizeObjects);   

            ChangeTempMatrix(x_pacman, y_pacman, 3);            // Внесение пакмена на временную матрицу ( 3 - обозначение пакмена)
        }

        void CreateWalls()                  // Создание стен
        {
            if (level == 1) CreateWalls1();
            else if (level == 2) CreateWalls2();
            else if (level == 3) CreateWalls3();
        }

        void CreateWalls1()              // 1 уровень
        {
            float a = 1.5f * sizeObjects;
            
            for (int i = (int)a; i < fieldSize; i += (2 * sizeObjects))
                for (int j = (int)a; j < fieldSize; j += (2 * sizeObjects))
                {
                    walls.Add(new Wall(i, j, sizeObjects));
                    ChangeTempMatrix(i, j, 2);                      // 2 - обозначение стены на временной матрице
                }
        }

        void CreateWalls2()              // 2 уровень
        {
            float a = 1.5f * sizeObjects;

            for (int j = (int)a; j < fieldSize; j += (2 * sizeObjects))
                for (int i = (int)a; i < fieldSize; i += (3 * sizeObjects))
                {
                    walls.Add(new Wall(i, j, sizeObjects));
                    ChangeTempMatrix(i, j, 2);

                    walls.Add(new Wall((i + sizeObjects), j, sizeObjects));
                    ChangeTempMatrix((i + sizeObjects), j, 2);
                }
        }

        void CreateWalls3()              // 3 уровень
        {
            float a = 1.5f * sizeObjects;

            for (int j = (int)a; j < fieldSize; j += (5 * sizeObjects))
                for (int i = (int)a; i < fieldSize; i += (3 * sizeObjects))
                {
                    walls.Add(new Wall(i, j, sizeObjects));
                    ChangeTempMatrix(i, j, 2);

                    walls.Add(new Wall((i + sizeObjects), j, sizeObjects));
                    ChangeTempMatrix((i + sizeObjects), j, 2);
                }

            for (int i = (int)a; i < fieldSize; i += (2 * sizeObjects))
                for (int j = (int)a + (2 * sizeObjects); j < fieldSize; j += (5 * sizeObjects))
                {
                    walls.Add(new Wall(i, j, sizeObjects));
                    ChangeTempMatrix(i, j, 2);

                    walls.Add(new Wall(i, (j + sizeObjects), sizeObjects));
                    ChangeTempMatrix(i, (j + sizeObjects), 2);
                }
        }

        void CreateGhosts()                 // Создание приведений
        {
            for (int n = 0; n < amountGhostsInLevel; n++)              // Цикл создания приведений
            {
                int ghost_i, ghost_j;         // Номер ячейки будущего приведения

                do
                {
                    ghost_i = r.Next(0, s);                 // Выбираем случайную пустую ячейку на временной матрице
                    ghost_j = r.Next(0, s);
                }
                while (tempMatrix[ghost_i, ghost_j] != 0);

                int x = ghost_i * sizeObjects + sizeObjects / 2;            // Определяем координаты будущего приведения
                int y = ghost_j * sizeObjects + sizeObjects / 2;

                ghosts.Add(new Ghost(x, y, sizeObjects));               // Добавляем новое приведение

                tempMatrix[ghost_i, ghost_j] = 4;                // Помечаем, что ячейка временной матрицы заполнена приведением
            }
            
        }

        void CreateDots()                   // Создание точек
        {
            for (int i = 0; i <= s - 1; i++)
                for (int j = 0; j <= s - 1; j++)
                {
                    if (tempMatrix[i, j] <= 1)
                    {
                        int x = i * sizeObjects + sizeObjects / 2;
                        int y = j * sizeObjects + sizeObjects / 2;
                        dots.Add(new Dot(x, y, sizeDots));
                    }

                }
        }

        #region Метод CreateDots() на время тестирования
        //void CreateDots()
        //{
        //    dots.Add(new Dot(300, 420, sizeDots));
        //}
        #endregion Метод CreateDots() на время тестирования

        #endregion Методы создания сущностей на игровом поле

        public void Play()    // Метод, обеспечивающий работу модели
        {
            while(gameStatus == GameStatus.playing)
            {
                Thread.Sleep(speedGame);

                PacmanRun();
                                
                TryTakeDot();

                GhostsRun();

                CheckCollision();

            }
        }

        #region Методы движения сущностей на игровом поле

        void CheckCollision()           // Проверка столкновения пакмена и приведений
        {
            foreach(Ghost a in ghosts)
            {
                if (Math.Abs(a.XCentre - pacman.XCentre) <= (3 * sizeObjects / 4) && Math.Abs(a.YCentre - pacman.YCentre) <= (3 * sizeObjects / 4))
                {
                    gameStatus = GameStatus.losing;
                    InformController();
                }

            }
        }

        void GhostsRun()                // Запуск одного шага движения приведений
        {
            foreach (Ghost a in ghosts)
            {
                bool canMoveUp = GhostCheckObstracle(0, -1, a.XCentre, a.YCentre);      // Проверка возможности движения в разных направлениях
                bool canMoveDown = GhostCheckObstracle(0, 1, a.XCentre, a.YCentre);
                bool canMoveLeft = GhostCheckObstracle(-1, 0, a.XCentre, a.YCentre);
                bool canMoveRight = GhostCheckObstracle(1, 0, a.XCentre, a.YCentre);

                bool tunnel = false;

                if ((canMoveUp && canMoveDown && !canMoveLeft && !canMoveRight)
                    ||
                    (!canMoveUp && !canMoveDown && canMoveLeft && canMoveRight))
                    tunnel = true;

                if (tunnel && GhostCheckObstracle(a.Direct_x, a.Direct_y, a.XCentre, a.YCentre))
                {
                    a.Run();        // Продолжение движения в прошлом направлении
                    continue;
                }

                int tempDirect_x, tempDirect_y;

                do
                {
                    tempDirect_x = r2.Next(-1, 2);
                    tempDirect_y = r2.Next(-1, 2);
                }
                while (!GhostCheckObstracle(tempDirect_x, tempDirect_y, a.XCentre, a.YCentre)
                        ||
                        (tempDirect_x == 0 && tempDirect_y == 0));


                a.Run(tempDirect_x, tempDirect_y);          // Движение по новому случайному направлению
            }
        }

        void PacmanRun()                // Запуск одного шага движения пакмена
        {
            if (PacmanCheckManualControl())
                pacman.Run(wantPacmanDirect_x, wantPacmanDirect_y);     // Движение пакмена в новом направлении 
            else
            {
                if (PacmanCheckAutomaticControl())
                    pacman.Run();                       // Продолжение движения в прошлом направлении 
            }
        }

        void TryTakeDot()               //  Попытка пакмена собрать точку
        {
            foreach(Dot a in dots)
            {
                if(a.XCentre == pacman.XCentre && a.YCentre == pacman.YCentre)
                {
                    takenDots++;
                    a.Death();
                    break;
                }
            }

            if (takenDots == dots.Count)
            {
                gameStatus = GameStatus.winner;
                InformController();
            }

        }



        bool GhostCheckObstracle(int tempDirect_x, int tempDirect_y, int ghostXCentre, int ghostYCentre) // Проверка возможности движения приведения
        {
            int testG_x, testG_y;
            testG_x = ghostXCentre + tempDirect_x;
            testG_y = ghostYCentre + tempDirect_y;

            foreach (Wall b in walls)
            {
                if (Math.Abs(b.XCentre - testG_x) < sizeObjects && Math.Abs(b.YCentre - testG_y) < sizeObjects)
                    return false;

                if (testG_x < (sizeObjects / 2) || testG_x > (fieldSize - (sizeObjects / 2)))
                    return false;

                if (testG_y < (sizeObjects / 2) || testG_y > (fieldSize - (sizeObjects / 2)))
                    return false;
            }

            return true;
        }

        bool PacmanCheckAutomaticControl()
        {
            tempP_D_x = pacman.Direct_x; tempP_D_y = pacman.Direct_y;
            return PacamnChecksObstacle();
        }

        bool PacmanCheckManualControl()
        {
            tempP_D_x = wantPacmanDirect_x; tempP_D_y = wantPacmanDirect_y;
            return PacamnChecksObstacle();
        }

        bool PacamnChecksObstacle()                     // Проверка возможности движения пакмена
        {
            testP_x = pacman.XCentre; testP_y = pacman.YCentre;

            testP_x += tempP_D_x; testP_y += tempP_D_y;

            foreach(Wall a in walls)
            {
                if (    Math.Abs(a.XCentre - testP_x) < sizeObjects && Math.Abs(a.YCentre - testP_y) < sizeObjects    )
                    return false;
            }
            if (testP_x < (sizeObjects / 2) || testP_x > (fieldSize - (sizeObjects / 2))  )
                return false;

            if (testP_y < (sizeObjects / 2) || testP_y > (fieldSize - (sizeObjects / 2))  )
                return false;

            return true;
        }

        #endregion Методы движения сущностей на игровом поле

        void ChangeTempMatrix(int x, int y, int field)      // Внесение изменений на временной матрице
        {
            int i = x / sizeObjects;
            int j = y / sizeObjects;

            if (field == 3)
            {
                for (int a = i - 2; a <= i + 2; a++)                       // Наносим ячейки ближайшего от пакмена пространства на временную матрицу
                    tempMatrix[a, j] = 1;                               // 1 - обозначение защищённой ячейки от приведений

                for (int b = j - 2; b <= j + 2; b++)
                    tempMatrix[i, b] = 1;
            }

            tempMatrix[i, j] = field;

        }

        void InformController()                   // Уведомление контроллера о завершении работы модели
        {
            if (changeStreep != null)
            {
                 changeStreep();
            }
        }
    }
}
