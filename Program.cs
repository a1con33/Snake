using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
	class Program
	{
		static void Main( string[] args )
		{
			Console.SetWindowSize(95, 25);

			Walls walls = new Walls( 80, 25 );
			walls.Draw();

			// Отрисовка точек		
			Point p = new Point( 4, 5, '*' );
			Snake snake = new Snake( p, 4, Direction.RIGHT );
			snake.Draw();

			// Создание еды
			FoodCreator foodCreator = new FoodCreator( 80, 25, '$', '-', '%' );
			Point food = foodCreator.CreateFood();
			Point badfood = foodCreator.CreateBadFood();
			Point specialfood = foodCreator.CreateSpecialFood();
			food.Draw();

			// Пути и настройки
			Params settings = new Params();

			// Аудио плеер
			Sounds sound = new Sounds(settings.GetResourceFolder());
			sound.Play();
			Sounds sound1 = new Sounds(settings.GetResourceFolder());
			Sounds sound2 = new Sounds(settings.GetResourceFolder());
			Sounds sound3 = new Sounds(settings.GetResourceFolder());
			Sounds sound4 = new Sounds(settings.GetResourceFolder());

			// Счёт
			Score score = new Score(settings.GetResourceFolder());


			while (true)
			{
				if ( walls.IsHit(snake) || snake.IsHitTail() )
				{
					sound.Stop("gamesound.mp3");
					sound2.PlayGameOver();
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
					sound1.PlayEat();
					score.UpCurrentPoints();
					score.ShowCurrentPoints();
					if (score.GetCurrentPoints() % 5 == 0)
					{
						specialfood = foodCreator.CreateSpecialFood();
						specialfood.Draw();
						badfood = foodCreator.CreateBadFood();
						badfood.Draw();
					}
				}

				if (snake.Eat(specialfood))
                {
					score.UpCurrentPointsx3();
					score.ShowCurrentPoints();
					sound3.PlayEatSpecialFood();
                }

				if(snake.Eat(badfood))
                {
					score.DownCurrentPoints();
					score.ShowCurrentPoints();
					sound4.PlayEatBadFood();
                }

				else
				{
					snake.Move();
				}

				new Speed(score.GetCurrentPoints());

				if ( Console.KeyAvailable )
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey( key.Key );
				}
			}

			score.WriteGameOver();
			score.WriteResult();
			Thread.Sleep(300);
			
		}
	}
}
