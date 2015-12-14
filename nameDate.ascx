<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nameDate.ascx.cs" Inherits="nameDate" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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
                    <cc1:CalendarExtender ID="birthTextBox_CalendarExtender" runat="server" 
                        BehaviorID="birthTextBox_CalendarExtender" Format="yy/MM/dd" 
                        onclientshown="dobCalendarShown" TargetControlID="birthTextBox">
                    </cc1:CalendarExtender>
                    <script type="text/javascript" language="javascript">
                        function dobCalendarShown(sender, args) {
                            sender._switchMode("years", true);
                        }
                    </script>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="birthTextBox" ErrorMessage="Please input your birthday.">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator" runat="server" 
            Type = "Date" ControlToValidate="birthTextBox" ErrorMessage = "Please input a valid date." Operator = "DataTypeCheck">*</asp:CompareValidator>

                </td>
                </tr>
</table>



<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>




