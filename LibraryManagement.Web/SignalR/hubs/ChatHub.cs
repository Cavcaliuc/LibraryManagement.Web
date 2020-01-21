using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using LibraryManagement.Web.Controllers;
using Microsoft.AspNet.SignalR;

namespace LibraryManagement.Web.SignalR.hubs
{
    public class ChatHub : Hub
    {
        private readonly OrderController _orderController =  DependencyResolver.Current.GetService<OrderController>();

        public void Send(string orderId, string name, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            var group = Clients.Group(orderId);

            // Send message to clients
            group.addNewMessageToPage(name, message);

            //Save message in DB
            _orderController.AddMessage(int.Parse(orderId), message);
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.Add(Context.ConnectionId, roomName);
        }
    }
}