using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConversationStarter.Controllers
{
    [BotAuthentication]
    public class BotController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody]Activity message)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
            if (message.Type == ActivityTypes.Message)
            {

                // GetConversationStarter(message); 

                var reply = message.CreateReply("");
                reply.TextFormat = TextFormatTypes.Plain;
                reply.Summary = $"Hero Card about bender";
                reply.Attachments = new List<Attachment>();
                reply.Attachments.Add(new Attachment()
                {
                    ContentType = HeroCard.ContentType,
                    Content = new HeroCard()
                    {
                        Title = "Bender Bending Rodríguez",
                        Subtitle = "Main character in the animated television series Futurama",
                        Text = "Bender Bending Rodríguez is a main character in the animated television series Futurama. He was created by series creators Matt Groening and David X. Cohen, and is voiced by John DiMaggio",
                        Images = new List<CardImage>()
                    {
                        new CardImage() { Url =  "http://cdn.overclock.net/7/72/72f33e5f_greybender.png", Alt="Bender_Rodriguez"}
                    },
                        Buttons = new List<CardAction>()
                    {
                         new CardAction()
                         {
                              Title = "Thumbs Up",
                              Type=ActionTypes.ImBack,
                              Image = "http://moopz.com/assets_c/2012/06/emoji-thumbs-up-150-thumb-autox125-140616.jpg",
                              Value="I like it"
                         },
                         new CardAction()
                         {
                              Title = "Thumbs Down",
                              Type=ActionTypes.ImBack,
                              Image = "http://yourfaceisstupid.com/wp-content/uploads/2014/08/thumbs-down.png",
                              Value="I don't like it"
                         },
                         new CardAction()
                         {
                             Title = "I feel lucky",
                             Type=ActionTypes.OpenUrl,
                             Image = "http://thumb9.shutterstock.com/photos/thumb_large/683806/148441982.jpg",
                             Value="https://www.bing.com/images/search?q=bender&qpvt=bender&qpvt=bender&qpvt=bender&FORM=IGRE"
                         }
                    },
                        Tap = new CardAction()
                        {
                            Type = ActionTypes.ImBack,
                            Value = "Tapped it!",
                            Title = "Tapped it!"
                        }

                    }
                });

                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                await connector.Conversations.SendToConversationAsync(reply);
            }
            else
            {
                HandleSystemMessage(message);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }


        private async void GetConversationStarter([FromBody]Activity message)
        {
            try
            {
                //Helper obj = new Helper();
                //List<Helper.FbUser> abc = obj.GetFacebookFeed();

                ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));

                var reply = message.CreateReply("");
                reply.TextFormat = TextFormatTypes.Plain;
                reply.Summary = $"Hero Card about bender";
                reply.Attachments = new List<Attachment>();
                reply.Attachments.Add(new Attachment()
                {
                    ContentType = HeroCard.ContentType,
                    Content = new HeroCard()
                    {
                        Title = "Bender Bending Rodríguez",
                        Subtitle = "Main character in the animated television series Futurama",
                        Text = "Bender Bending Rodríguez is a main character in the animated television series Futurama. He was created by series creators Matt Groening and David X. Cohen, and is voiced by John DiMaggio",
                        Images = new List<CardImage>()
                    {
                        new CardImage() { Url =  "http://cdn.overclock.net/7/72/72f33e5f_greybender.png", Alt="Bender_Rodriguez"}
                    },
                        Buttons = new List<CardAction>()
                    {
                         new CardAction()
                         {
                              Title = "Thumbs Up",
                              Type=ActionTypes.ImBack,
                              Image = "http://moopz.com/assets_c/2012/06/emoji-thumbs-up-150-thumb-autox125-140616.jpg",
                              Value="I like it"
                         },
                         new CardAction()
                         {
                              Title = "Thumbs Down",
                              Type=ActionTypes.ImBack,
                              Image = "http://yourfaceisstupid.com/wp-content/uploads/2014/08/thumbs-down.png",
                              Value="I don't like it"
                         },
                         new CardAction()
                         {
                             Title = "I feel lucky",
                             Type=ActionTypes.OpenUrl,
                             Image = "http://thumb9.shutterstock.com/photos/thumb_large/683806/148441982.jpg",
                             Value="https://www.bing.com/images/search?q=bender&qpvt=bender&qpvt=bender&qpvt=bender&FORM=IGRE"
                         }
                    },
                        Tap = new CardAction()
                        {
                            Type = ActionTypes.ImBack,
                            Value = "Tapped it!",
                            Title = "Tapped it!"
                        }

                    }
                });

                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                await connector.Conversations.SendToConversationAsync(reply);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
