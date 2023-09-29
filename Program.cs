using System;
using Telegram.Bot;
using Telegram.Bot.Polling;
using System.Diagnostics;
using Telegram.Bot.Types.ReplyMarkups;
using NAudio.CoreAudioApi;
using Telegram.Bots.Http;
using Telegram.Bots.Types;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

//using System.Runtime.InteropServices;
namespace TelegramBotExperiments
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient(""); //telegram bot token
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
                if (update.Type != Telegram.Bot.Types.Enums.UpdateType.Message)
                    throw new Exception();
                var message = update.Message;
                if (message.Text == null)
                    throw new Exception();
                double volume = -1.0;
                var enumerator = new MMDeviceEnumerator();
                var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                var currentvolume = device.AudioEndpointVolume.MasterVolumeLevelScalar;
                switch (message.Text.ToLower())
                {
                    case "/start":
                    case "🔙 назад":
                        var keyboard = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("🎮 Steam"),
                                new KeyboardButton("🌏 Браузер"),
                            },
                            new[]
                            {
                                new KeyboardButton("📞 Discord"),
                                new KeyboardButton("👥 Telegram"),
                            },
                            new[]
                            {
                                new KeyboardButton("🎧 Установить громкость"),
                            }
                        })
                        {
                            ResizeKeyboard = true    
                        };
                        await botClient.SendTextMessageAsync(message.Chat, "🏡 Главная страница", replyMarkup: keyboard);
                        break;

                    case "👥 telegram":
                        Process.Start("C:\\Users\\Professional\\AppData\\Roaming\\Telegram Desktop\\Telegram.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    case "📞 discord":
                        Process.Start("C:\\Users\\Professional\\AppData\\Local\\Discord\\Update.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    
                    case "🎮 steam":
                        var keyboard3 = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("🌳 Valheim"),
                                new KeyboardButton("🚨 GTA 5"),
                                new KeyboardButton("🌆 Wallpaper"),
                            },
                            new[]
                            {
                                new KeyboardButton("🔞 DOTA 2"),
                                new KeyboardButton("🎮 stеam"),
                                //new KeyboardButton("💣 CS:GO"),
                            },
                            new[]
                            {
                                new KeyboardButton("🔙 Назад"),
                            }
                        })
                        {
                            ResizeKeyboard = true
                        };
                        botClient.SendTextMessageAsync(message.Chat, "Выберете игру", replyMarkup: keyboard3);
                        break;

                    case "🌳 valheim":
                        Process.Start("D:\\Program Files (x86)\\Steam\\steamapps\\common\\Valheim\\valheim.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    case "🚨 gta 5":
                        Process.Start("D:\\Program Files (x86)\\Steam\\steamapps\\common\\Valheim\\valheim.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    case "🌆 wallpaper":
                        Process.Start("D:\\Program Files (x86)\\Steam\\steamapps\\common\\wallpaper_engine\\wallpaper64.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    case "🔞 dota 2":
                        Process.Start("D:\\Program Files (x86)\\Steam\\steamapps\\common\\dota 2 beta\\game\\bin\\win64\\dota2.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    case "🎮 stеam":
                        Process.Start("D:\\Program Files (x86)\\Steam\\Steam.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    //case "💣 cs:go":
                        Process.Start("D:\\Program Files (x86)\\Steam\\steamapps\\common\\Counter-Strike Global Offensive\\csgo.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;

                    case "🌏 браузер":
                        var keyboard1 = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("🎧 Музыка"),
                                new KeyboardButton("🌍 Браузер"),
                                new KeyboardButton("👥 Вконтакте"),
                            },
                            new[]
                            {
                                new KeyboardButton("📖 ВГЛТУ"),
                                new KeyboardButton("🍓 PornHub"),
                                new KeyboardButton("📺 YouTube"),
                            },
                            new[]
                            {
                                new KeyboardButton("🔙 Назад"),
                            }
                        })
                        {
                            ResizeKeyboard = true
                        };
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено", replyMarkup: keyboard1);
                        break;

                    case "🌍 браузер":
                        Process.Start("C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;

                    case "📺 youtube":
                        Process.Start("C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe", "https://www.youtube.com/");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                        
                    case "🍓 pornhub":
                        Process.Start("C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe", "https://rt.pornhub.com/");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;

                    case "🎧 музыка":
                        Process.Start("C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe", "https://music.yandex.ru/home");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;
                    
                    case "👥 вконтакте":
                        Process.Start("C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe", "https://vk.com/feed");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;

                    case "📖 вглту":
                        Process.Start("C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe", "https://vgltu.ru/obuchayushchimsya/raspisanie-zanyatij/");
                        botClient.SendTextMessageAsync(message.Chat, "✅ успешно выполнено");
                        break;

                    case "🎧 установить громкость":
                        var keyboard2 = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("🎧 Максимальная громкость"),
                                new KeyboardButton("🎧 Выключить громкость"),
                            },
                            new[]
                            {
                                new KeyboardButton("25%"),
                                new KeyboardButton("50%"),
                                new KeyboardButton("75%"),
                            },
                            new[]
                            {
                                new KeyboardButton("+10%"),
                                new KeyboardButton("-10%"),
                                new KeyboardButton("+20%"),
                                new KeyboardButton("-20%"),
                            },
                            new[]
                            {
                                new KeyboardButton("🔙 Назад"),
                            }
                        })
                        {
                            ResizeKeyboard = true
                        };
                        botClient.SendTextMessageAsync(message.Chat, "Выберете действие", replyMarkup: keyboard2);
                        break;
                    case "25%":
                        volume = 0.25;
                        break;
                    case "50%":
                        volume = 0.50;
                        break;
                    case "75%":
                        volume = 0.75;
                        break;
                    case "🎧 максимальная громкость":
                        volume = 1;
                        break;
                    case "🎧 выключить громкость":
                        volume = 0;
                        break;
                    case "+10%":
                        volume = currentvolume + 0.1;
                        break;
                    case "-10%":
                        volume = currentvolume - 0.1;
                        break;
                    case "+20%":
                        volume = currentvolume + 0.2;
                        break;
                    case "-20%":
                        volume = currentvolume - 0.2;
                        break;


                    default:
                        await botClient.SendTextMessageAsync(message.Chat, "❌ Неверная команда");
                        break;
                }
                if (volume != -1.0)
                {
                    ChangeVolume(volume, botClient, message);
                }
            }
            catch(Exception ex)
            {
                return;
            }       
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        public static async Task ChangeVolume(double volume, ITelegramBotClient botClient, Telegram.Bot.Types.Message message)
        {
            if (volume < 0)
                volume = 0;
            if (volume > 1)
                volume = 1;
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)volume;
            botClient.SendTextMessageAsync(message.Chat, $"Текущая громкость: {Math.Round(device.AudioEndpointVolume.MasterVolumeLevelScalar*100)}%");
        }

        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetConsoleWindow();

        //[DllImport("user32.dll")]
        //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //const int HIDE = 0;
        //const int SHOW = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            //ShowWindow(GetConsoleWindow(), HIDE);
            Console.ReadLine();
        }
    }
}