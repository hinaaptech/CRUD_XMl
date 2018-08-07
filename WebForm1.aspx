<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUD_Xml.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

      <div style="text-align:center;color:maroon;border-bottom:double;border-bottom-color:sandybrown;"> 
           <h1> 	XML with ASP.NET Web Forms </h1> </div> 

    <br /><br /><br />

           <table cellpadding="2" cellspacing="2" border="1" width="70%" align="center">
      <tr>               
         <td>
                    <asp:ListView ID="EmployeeListView" runat="server" InsertItemPosition="LastItem"  
                        OnItemInserting="EmployeeListView_ItemInserting"
                        OnItemDeleting="EmployeeListView_ItemDeleting"
                        OnItemEditing="EmployeeListView_ItemEditing"
                        OnItemCanceling="EmployeeListView_ItemCanceling">
                        <LayoutTemplate>
                            <table id="Table1" runat="server" width="100%">
                                <tr id="Tr1" runat="server">
                                    <td id="Td1" runat="server">
                                        <table id="itemPlaceholderContainer" runat="server" border="0" style="" width="100%">
                                            <tr id="Tr2" runat="server" style="background-color:maroon;height:'100px'  ">
                                              <th id="Th2" runat="server" align="center" style="color: white; ">
                                                    Name
                                                </th>
                                                <th id="Th3" runat="server" align="center" style="color: White;">
                                                    Mobile
                                                </th>
                                                <th id="Th4" runat="server" align="center" style="color: White;">
                                                    City
                                                </th>
                                                <th id="Th5" runat="server" align="center" style="color: White;">
                                                    Country
                                                </th>
                                                <th id="Th1" runat="server" align="center" style="color: White;">
                                                </th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server" style="color: White;">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="Tr3" runat="server">
                                    <td id="Td2" runat="server" style="">
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr style="background-color:#0b3f5e;color:whitesmoke;">
                                <td align="center">
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>' />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>' />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>' />
                                </td>
                                <td align="center">
           <asp:ImageButton ID="DeleteButton" runat="server" CommandName="Delete" ImageUrl="~/Delete_Marker.png" Width="75px" />
            <asp:ImageButton ID="EditButton" runat="server" CommandName="Edit" ImageUrl="~/edit.jpg" Height="70px" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color:chocolate; color:white">
                                <td align="center">
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>' />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>' />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>' />
                                </td>
                                <td align="center">
                    <asp:ImageButton ID="DeleteButton" runat="server" CommandName="Delete" ImageUrl="~/Delete_Marker.png" Width="75px" />
                    <asp:ImageButton ID="EditButton" runat="server" CommandName="Edit" ImageUrl="~/edit.jpg" Height="70px" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <InsertItemTemplate>
                            <tr style="">
                                <td>
                     <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/Addrec.ico" Height="45px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMobile" runat="server" Text='<%# Bind("Mobile") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("City") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCountry" runat="server" Text='<%# Bind("Country") %>' />
                                </td>
                                <td>
                 <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/edit.jpg" OnClick="btnUpdate_Click"  Height="40px" />
                 <asp:ImageButton ID="CancelButton" runat="server" CommandName="Cancel" ImageUrl="~/images.jpg" Height="45px" />
                                </td>
                            </tr>
                        </InsertItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
