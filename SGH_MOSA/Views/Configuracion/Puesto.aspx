<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Puestos - SGH
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="StyleSheets" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="nombreVista" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="TituloVista" runat="server">
    <h1>Puestos</h1>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="BreadCrumb" runat="server">
    <li class="breadcrumb-item"><a href="#">Configuración</a></li>
    <li class="breadcrumb-item active">Puestos</li>
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="TituloContenido" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">

    <!-- left column -->
          <div class="col-md-4">
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Puesto Nuevo</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
              <form>
                <div class="card-body">
                  <%--<div class="form-group">
                    <label for="idPuesto">ID</label>
                    <input type="text" class="form-control" id="idPuesto"  disabled="disabled" >
                  </div>--%>
                  <div class="form-group">
                    <label for="codPuesto">Codigo del Puesto</label>
                    <input type="text" class="form-control" id="codPuesto" placeholder="Codigo del Puesto">
                  </div>
                     <div class="form-group">
                    <label for="nomPuesto">Nombre del Puesto</label>
                    <input type="text" class="form-control" id="nomPuesto" placeholder="Nombre del Puesto">
                  </div>
                </div>
                <!-- /.card-body -->

                <div class="card-footer">
                  <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                </div>
              </form>
            </div>
          </div>

    <div class="col-md-8">
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Lista de Puestos</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                 <!-- /.card-header -->
              <div class="card-body table-responsive p-0">
                <table class="table table-hover text-nowrap" id="table-puestos">
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>Codigo</th>
                      <th>Descripción</th>
                      <th>Editar</th>
                    </tr>
                  </thead>
                    </table>

              </div>
            </div>
            <!-- /.card -->
        </div>
     
     <div class="modal fade" id="modal-default">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Editar Puesto</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">

                  <div class="form-group">
                    <label for="idPuestoModal">ID</label>
                    <input type="text" class="form-control" id="idPuestoModal"  disabled="disabled" >
                  </div>
                  <div class="form-group">
                    <label for="codPuestoModal">Codigo del Puesto</label>
                    <input type="text" class="form-control" id="codPuestoModal"  disabled="disabled">
                  </div>
                     <div class="form-group">
                    <label for="nomPuestoModal">Nombre del Puesto</label>
                    <input type="text" class="form-control" id="nomPuestoModal" placeholder="Nombre del Puesto">
                  </div>

            </div>
            <div class="modal-footer justify-content-between">
              <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
              <button type="button" class="btn btn-primary" id="btnActualiza">Actualizar</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
</div>

</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="footerBodyContent" runat="server">
</asp:Content>

<asp:Content ID="Content9" ContentPlaceHolderID="JSScipts" runat="server">
    <script src="../../Content/js/Configuracion/Puesto.js"></script>
</asp:Content>
