<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Login.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <form method="post" action="/User/Login">
        <div class="input-group mb-3">
          <input type="email" name="UserName" id="UserName" class="form-control" placeholder="Email" >
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <input type="password"  name="UserPassword" id="UserPassword"  class="form-control" placeholder="Password">
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <br />
          </div>
          <!-- /.col -->
          <div class="col-4">
            <button type="submit" class="btn btn-primary btn-block">Sign In</button>
          </div>
          <!-- /.col -->
        </div>
      </form>

   <%-- <div class="container">

        <div class="login-box">

            <div class="col-sm-12 text-center login-header">

            </div>
            <div class="col-sm-12">

                <div class="login-body">


                </div>
                <form method="post" action="/User/Login">

                    <div class="control">

                        <div class="form-group">
                            <input type="text" name="UserName" id="UserName" class="form-control" placeholder="Usuario" value=""/>
                        </div>
                    </div>
                    <div class="control">
                        <input type="password" name="UserPassword" id="UserPassword" class="form-control" placeholder="clave" value="" />
                    </div>
                    <div class="login-button text-center">
                        <input type="submit" class="btn btn-primary" value="Ingresar" />
                    </div>

                </form>
            </div>
            <div class="login-footer">
                <span class="text-right"><a href="#" class="color-white">Necesita Ayuda?</a></span>
            </div>

        </div>


    </div>--%>



</asp:Content>
