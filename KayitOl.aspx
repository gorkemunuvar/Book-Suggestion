<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KayitOl.aspx.cs" Inherits="KayitOl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        #container {
            width: 750px;
            height: 300px;
            position: absolute;
            left: 37%;
            top: 20%;
            margin-left: -50px;
            margin-top: -50px;
        }

        .auto-style1 {
            width: 116px;
        }
    </style>
    <title></title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#dttpTarih").datepicker({
                showOn: "button",
                buttonImage: "takvim.png",
                buttonImageOnly: true,
                dateFormat: "dd.mm.yy",
                monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
                dayNamesMin: ["Pts", "Sl", "Çrş", "Prş", "Cm", "Cts", "Pzr"]
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <table cellpadding="1" border="0">
                <tr>
                    <td align="center" colspan="3">
                        <hr />
                        Kayıt Paneli
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="labelAd">Ad:</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAd"></asp:TextBox>
                    </td>
                    <td rowspan="8" class="auto-style1">
                        <center>
                        <asp:Image ID="Image1" runat="server" Height="124px" Width="109px" ImageUrl="~/Resimler/profil.png" />
                        <br />
                        
                            <asp:FileUpload ID="FileUploadFoto" runat="server" Width="194px" />
                    </center>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="labelSoyad">Soyad:</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSoyad"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="labelKullaniciAdi">Kullanıcı Adı:</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtKullaniciAdi"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="labelParola">Parola:</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtParola"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="labelParolaTekrar">Parola Tekrar:</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtParolaTekrar"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="lblCinsiyet">Cinsiyet:</asp:Label></td>
                    <td>
                        <asp:RadioButton ID="radioErkek" Text="E" GroupName="medeniHal" runat="server" />
                        <asp:RadioButton ID="radioKadın" Text="K" GroupName="medeniHal" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="labelDogumTarihi">Doğum Tarihi:</asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDogumTarihi" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label runat="server" ID="lblMail">Mail:</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMail"></asp:TextBox>
                    </td>
                </tr>




                <tr>
                    <td align="center" colspan="3" style="color: Red;">
                        <asp:Label ID="lblSonuc" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="3">
                        <hr />
                        <asp:Button runat="server" CommandName="Kayit" Text="Kayıt Ol" ID="btnKayitOl" OnClick="btnKayitOl_Click"></asp:Button>
                        <hr />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
