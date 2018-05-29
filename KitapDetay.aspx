<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KitapDetay.aspx.cs" Inherits="KitapDetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style1 {
            margin-left: 78px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <hr />
                <center>
                    <asp:Label ID="labelKitapDetay" runat="server" Text="Kitap Detay"></asp:Label>
               </center>
                <hr />
            </div>
            <div>
                <table border="0" cellpadding="0">
                    <tr>
                        <td rowspan="7" class="auto-style6">
                            <center>
                                <asp:Image ID="imgKitap" runat="server" Height="180px" Width="134px" ImageUrl="~/Resimler/ZamaninDahaKisaTarihi.jpg" />
                                 <br />
                             </center>
                        </td>

                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelOrtalamaPuan"><b>Ort. Puan:</b></asp:Label>
                        </td>

                        <td rowspan="8" align="center"></td>


                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelOkunmaSayisi"><b>Okunma Sayısı:</b></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelKitapAdi"><b>Kitap Adı:</b></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelYazar"><b>Yazarı:</b></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelYayinEvi"><b>Yayın Evi:</b></asp:Label>
                        </td>
                    </tr>


                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelTanitim"><b>Tanıtım:</b> </asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnOkudum" Text="Okudum" OnClick="btnOkudum_Click" runat="server" />
                            <asp:Button ID="btnPuanVer" Text="Puan Ver" OnClick="btnPuanVer_Click" runat="server" />
                            <asp:TextBox ID="txtPuan" runat="server" Width="20px"></asp:TextBox>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="labelSonuc" runat="server" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" colspan="2">
                            <center>
                                <hr />
                                    Kitap Hakkındaki İnceleme Ve Yorumlar
                                    <hr />
                            </center>
                            <asp:GridView ID="gVIncelemeler" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="490px">
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
                            <asp:TextBox ID="txtInceleme" runat="server" Width="307px"></asp:TextBox>
                            <asp:Button ID="btnInceleme" Text="İnceleme Ekle" OnClick="btnInceleme_Click" runat="server" CssClass="auto-style1" />
                            <hr />
                            <br />
                        </td>

                        <td cellpadding="0" valign="top" >
                            <center>
                                <hr />
                                    Alıntılar
                                <hr />
                            </center>
                            <asp:GridView ID="gVAlintilar" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="462px">
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
                            <br />  
                            <hr />
                            <asp:Label ID="Label1" runat="server" Text="Sayfa:"></asp:Label>
                            <asp:TextBox ID="txtSayfa" runat="server" Width="27px"></asp:TextBox>
                            <asp:TextBox ID="txtAlinti" runat="server" Width="311px" CssClass="auto-style2"></asp:TextBox>
                            <asp:Button ID="btnAlintiEkle" Text="Alıntı Ekle" runat="server" OnClick="btnAlintiEkle_Click" />
                            <hr />
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </form>
</body>
</html>
