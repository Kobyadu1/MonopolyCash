#pragma checksum "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96f0a31da0c911e3d19419ce2de3dfc16ab2693f"
// <auto-generated/>
#pragma warning disable 1591
namespace MonopolyCash.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using MonopolyCash;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/lobby")]
    public partial class Lobby : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<style>
.container {
  height: 500px;
  position: relative;
  border: 3px solid green;
}

.center {
  margin: 0;
  position: absolute;
  top: 50%;
  left: 50%;
  -ms-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
}
</style>

");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "container");
            __builder.AddAttribute(3, "style", "background-color:powderblue;");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "center");
#nullable restore
#line 27 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
         if (playerData == null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "<p><em>Loading...</em></p>");
#nullable restore
#line 30 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
        }
        else 
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(7, "p");
            __builder.AddContent(8, "Lobby Key: ");
            __builder.AddContent(9, 
#nullable restore
#line 33 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
                       gameKey

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "table");
            __builder.AddAttribute(12, "class", "table");
            __builder.AddMarkupContent(13, "<thead><tr><th>Name</th>\r\n                    <th>Status</th></tr></thead>\r\n            ");
            __builder.OpenElement(14, "tbody");
#nullable restore
#line 42 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
                 foreach (KeyValuePair<string,string> player in playerData)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(15, "tr");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 45 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
                             player.Key

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                        ");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 46 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
                             player.Value

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 48 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n        ");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "class", "btn btn-primary");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 51 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
                                                  update

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "Ready?");
            __builder.CloseElement();
#nullable restore
#line 52 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
        } 

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n}\r\n\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "C:\Users\kobya\Desktop\Code Folders\VS Code\MonopolyCash\Pages\Lobby.razor"
       
    Dictionary<String,String> playerData;
    HubConnection connection;
    string gameKey;
    int playerID;

    protected override async Task OnInitializedAsync()
    {
        connection = new HubConnectionBuilder()
        .WithUrl("https://monopolycash20210106194636.azurewebsites.net/gamehub")
        .Build();
        await connection.StartAsync();
        connection.On<String[]>("joinedRoom", NotifyUserJoin);
        connection.On<String>("ready", NotifyUserReady);

        playerID = await localStorage.GetItemAsync<int>("playerID");
        playerData = await connection.InvokeAsync<Dictionary<String, String>>("readStatus",playerID);
        Object[] data = await connection.InvokeAsync<Object[]>("getPlayerData",playerID);
        gameKey = data[4].ToString();
    }
    async Task NotifyUserJoin(String[]data) 
    {
        if(data[1].Equals(gameKey))
        {
            toastService.ShowInfo(data[0] + " has joined the lobby.");
            playerData = await connection.InvokeAsync<Dictionary<String, String>>("readStatus",playerID);
            StateHasChanged();
            await Task.CompletedTask;
        }
        else 
        {
            await Task.CompletedTask;  
        }
    }
    async Task NotifyUserReady(String gameKey) 
    {
        if(this.gameKey.Equals(gameKey))
        {
            playerData = await connection.InvokeAsync<Dictionary<String, String>>("readStatus",playerID);
            StateHasChanged();
            await Task.CompletedTask;
        }
        else 
        {
            await Task.CompletedTask;  
        }
    }

    private async void update()
    {
        await connection.InvokeAsync("updateStatus",playerID);
        playerData = await connection.InvokeAsync<Dictionary<String, String>>("readStatus",playerID);
        StateHasChanged();
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
