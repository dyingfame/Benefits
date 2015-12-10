<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nameDate.ascx.cs" Inherits="nameDate" %>


<style type="text/css">
    .style1
    {
        width: 335px;
    }
</style>



<table class="style1">
    <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="nameTextBox" ErrorMessage="Please input your name.">*</asp:RequiredFieldValidator>
                </td>
                </tr>
    <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Birth Date:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="birthTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="birthTextBox" ErrorMessage="Please input your birthday.">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator" runat="server" 
            Type = "Date" ControlToValidate="birthTextBox" ErrorMessage = "Please input a valid date." Operator = "DataTypeCheck">*</asp:CompareValidator>

                </td>
                </tr>
</table>



