using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQBot
{
    /// <summary>
    /// 定义事件
    /// </summary>
    public class EventHandlerTest
    {
        /// <summary>
        /// 定义委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void UserRequest(object sender, EventArgs e);

        /// <summary>
        /// 定义此委托类型的事件
        /// </summary>
        public event UserRequest OnUserRequest;
        public EventHandlerTest()
        {
            UserEventMonitor uem = new UserEventMonitor(this);
        }
        public void DoRun()
        {
            bool flag = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("请输入：");
                string result = Console.ReadLine();
                if (result == "1")
                {
                    if (OnUserRequest != null)
                    {
                        OnUserRequest(this, new EventArgs());
                    }
                }
            } while (!flag);
        }
    }

    /// <summary>
    /// 事件监听
    /// </summary>
    public class UserEventMonitor
    {
        public UserEventMonitor(EventHandlerTest eht)
        {
            eht.OnUserRequest += delegate
            {
                Console.WriteLine("Hello World!!");
            };
        }
        public void ShowMessage(object sender,EventArgs e)
        {
            Console.WriteLine("Hello Word!!");
        }
    }
}
