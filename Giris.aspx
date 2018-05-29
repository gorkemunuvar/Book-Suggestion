<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        #container {
            width: 350px;
            height: 150px;
            position: absolute;
            left: 42%;
            top: 30%;
            margin-left: -50px;
            margin-top: -50px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <table cellpadding="3" border="0">
                <tr>
                    <td align="center" colspan="2">
                        <hr />
                        Giriş Paneli
                        <hr />
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
                    <td align="center" colspan="2" style="color: Red;">
                        <asp:Label ID="lblSonuc" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <hr />
                        <asp:Button runat="server" CommandName="Giriş" Text="Giriş" ID="btnGiris" OnClick="btnGiris_Click"></asp:Button>
                        <asp:Button runat="server" CommandName="Kayit" Text="Kayıt Ol" ID="btnKayitOl" OnClick="btnKayitOl_Click"></asp:Button>
                        <hr />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
