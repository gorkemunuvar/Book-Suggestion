<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopulerYazarlar.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kitap Değerlendirme Ve Tavisye Sistemi</title>
    <meta charset="UTF-8" />
    <link rel="StyleSheet" type="text/css" href="StyleSheet.css" />
    <style type="text/css">
        #iskelet {
            height: 594px;
        }
        #div3 {
            height: 526px;
        }
    </style>
</head>
<body style="height: 601px">
    <form id="form1" runat="server">
        <div class="ana_div" id="iskelet">
            <div class="div1" id="div1">
                <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px" Height="163px" Width="85px">
                    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#F7F6F3" />
                    <DynamicSelectedStyle BackColor="#5D7B9D" />
                    <Items>
                        <asp:MenuItem Text="Tavsiyeler" Value="Tavsiyeler" NavigateUrl="~/Tavsiyeler.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Kitaplar" Value="Kitaplar" NavigateUrl="~/Kitaplar.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Yazarlar" Value="Yazarlar" NavigateUrl="~/Yazarlar.aspx" Selected="True"></asp:MenuItem>
                        <asp:MenuItem Text="Kullanıcılar" Value="Kullanıcılar" NavigateUrl="~/Kullanicilar.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Profilim" Value="Profilim" NavigateUrl="~/Profilim.aspx"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#5D7B9D" />
                </asp:Menu>
            </div>

            <div class="div" id="div2">
                <hr />
                <center>
                    <asp:Label ID="Label1" runat="server" Text="Popüler Yazarlar"></asp:Label>
               </center>
                <hr />
            </div>
            <div class="div" id="div3">
                <table border="0 " cellpadding="0">
                    <tr>
                        <td>
                            <hr />
                            <asp:Label ID="labelYazarAra" runat="server">Yazar Ara:</asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                            <asp:TextBox ID="txtYazarAra" runat="server" Width="147px" OnTextChanged="txtYazarAra_TextChanged"></asp:TextBox>
                            <hr />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gVYazarlar" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gVYazarlar_SelectedIndexChanged" AutoGenerateSelectButton="True" OnInit="gVYazarlar_Init">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                            <hr />
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </form>
</body>
</html>
