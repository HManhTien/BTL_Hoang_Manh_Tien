

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Runtime.CompilerServices;
using System.Data.SqlTypes;

namespace chatbotc
{

    public partial class Form1 : Form
    {

        public TelegramBotClient botClient;
        public long chatId = 5937441817 ; 

        int logCounter = 0;

        void AddLog(string msg)
        {
            if (txtlog.InvokeRequired)
            {
                txtlog.BeginInvoke((MethodInvoker)delegate ()
                {
                    AddLog(msg);
                });
            }
            else
            {
                logCounter++;
                if (logCounter > 100)
                {
                    txtlog.Clear();
                    logCounter = 0;
                }
                txtlog.AppendText(msg + "\r\n");
            }
            Console.WriteLine(msg);
        }
   
        public Form1()
        {
            InitializeComponent();
            //ID Token 
            string token = "6062892512:AAHzsoa1N2umQrCyNPCguC9jVCfoJYVZUhQ";

            //Tao bot moi
            botClient = new TelegramBotClient(token);

            CancellationTokenSource cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>() //
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,  
                pollingErrorHandler: HandlePollingErrorAsync,   // Hàm này sử lý lỗi -> có lỗi là gọi thằng này
                receiverOptions: receiverOptions,               // Thằng này đc new ở trên kìa tham số cài đặt về việc cập nhật mới
                cancellationToken: cts.Token                      // Thằng này là hủy cts.Token  -> hủy nó làm j ?
                                               
                                            
            );

            Task<User> me = botClient.GetMeAsync(); //
            
            AddLog($"Thằng bot: @{me.Result.Username}");

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
               
                bool ok = false;

                //dac biet = null
                Telegram.Bot.Types.Message message = null;


                // tin nhan moi 
                if (update.Message != null)  
                {                 
                    message = update.Message;
                    ok = true;
                }
                
                // neu tin nhan dc sua
                if (update.EditedMessage != null)
                {
                    message = update.EditedMessage;
                    ok = true;
                }

                
                if (!ok || message == null) return;               
                string messageText = message.Text;
                if (messageText == null) return; 

                chatId = message.Chat.Id;  
                AddLog($"{chatId}: {messageText}");  

                string reply = ""; 
                string messLow = messageText.ToLower(); 




                // Hoi
                if (messLow.StartsWith("gv"))
                {
                    reply = "FeedBack Giáo viên:🥲 Môn học lập trình Windows thầy Đỗ Duy Cốp. Giảng quá xá là HAY!😍😍";
                }              
                else if (messLow.StartsWith("kh "))
                {
                    string tenKH = messageText.Substring(3);
                    reply = HoiDap.timkiemkhachhang("%" + tenKH+ "%");
                   
                }
                else if (messLow.StartsWith("hd "))
                {
                    string Tenhoadon = messageText.Substring(3);
                    reply = HoiDap.tkhd("%" + Tenhoadon.Replace(" " ,"%") + "%");
                }
                else if(messLow.StartsWith("codeby"))
                {
                    reply = " - Hoàng Mạnh Tiến  \n\r  Lớp 56KMT   \n\r  Học Rất dốt ";
                    
                }
                else if(messLow.StartsWith("thoi tiet"))
                {

                }
                else
                {
                    reply = "🤡Tôi nói pạn nghe: " + messageText;
                }


                // Dap
                AddLog(reply);               
                Telegram.Bot.Types.Message sentMessage = await botClient.SendTextMessageAsync(
                           
                           chatId: chatId, 
                           text: reply,    
                           parseMode: ParseMode.Html  
                      );     
            }   
            // Thong bao loi 
            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                Console.WriteLine("Loi roi");
                AddLog("--------  Lỗi rồi -> K rõ lỗi j  -----------");
                return Task.CompletedTask;
            }
        }

        private void formBot_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

