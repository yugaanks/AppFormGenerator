<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AppFormGenerator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Select Form" runat="server" />
        <asp:DropDownList runat="server" ID="forms" OnSelectedIndexChanged="Form_Selection_Change" AutoPostBack="true">
            <asp:ListItem Selected="True" Text="" />
            <asp:ListItem Text="EIANotification" Value="EIANotification" />
        </asp:DropDownList>
        <asp:Panel runat="server" ID="formPanel" Visible="false">
            <div>
                <asp:Label runat="server" ID="FirstName">First Name:</asp:Label>
                <asp:TextBox runat="server" ID="CandidateFirstName"></asp:TextBox>
            </div>
            <div>
                <asp:Label Text="Last Name" ID="LastName" runat="server" />
                <asp:TextBox runat="server" ID="CandidateLastName" />
            </div>
            <div>
                <asp:Button Text="Submit" ID="Submit" runat="server" OnClick="Submit_button_Click" />
            </div>
            <div>
                <asp:Button Text="Draft Email" ID="SendEmail" runat="server" Enabled="false" />
            </div>
            <div>
                <asp:Label ID="Template" runat="server" />
            </div>
        </asp:Panel>
    </form>

</body>
</html>
