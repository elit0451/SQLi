<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SQLi._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #usernameInput {
            width: 385px;
        }
        #passwordInput {
            width: 393px;
        }
    </style>
</head>
<body>
    <h2>Type in a username to show users informations</h2>

    <form id="form1" runat="server">
    <div>
        <asp:Label ID="displayLabel" runat="server" Text="No data to show"></asp:Label>
        <br />
        <input id="usernameInput" runat="server" placeholder="Type your username" /><br />
        <br />
&nbsp;<asp:Button ID="Button1" OnClick="login" runat="server" Text="Find" />

        
    </div>
    </form>
</body>
</html>
