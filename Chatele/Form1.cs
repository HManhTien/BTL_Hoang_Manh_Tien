using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


using Telegram.Bot;
using Message = Telegram.Bot.Types.Message;

namespace Chatele
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TelegramBotClient Botclient;

        private void Form1_Load(object sender, EventArgs e)
        {
            Botclient = new TelegramBotClient("6118029010:AAGVF3-PnfU8nqoDDlApjCKVl-GuNCGyqEc");
            Starreview();
        }

        public async Task Starreview()
        {
            var token = new CancellationTokenSource();
            var canceltoken = token.Token;
            var reOpt = new ReceiverOptions { AllowedUpdates = { } };
            await Botclient.ReceiveAsync(OnMessage, ErrorMessage, reOpt, canceltoken);
        }

        public async Task OnMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, " helo bro ");
            } 
        }

        public async Task ErrorMessage(ITelegramBotClient telegramBot, Exception e, CancellationToken cancellationToken)
        {
            if (e is ApiRequestException requestException)
            {
                await Botclient.SendTextMessageAsync(" ", e.Message.ToString());
            }
        }
    }
}