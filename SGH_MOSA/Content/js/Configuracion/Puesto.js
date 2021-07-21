

$(document).ready(function () {

    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });


    //$("#table-puestos").hide();

    dbDataPuestos();

    function dbDataPuestos() {
        $.ajax({
            url: "/Configuracion/GetPuestos/",
            method: "GET",
            dataType: "json",
            success: function (data) {
                $("#table-puestos").dataTable({
                    data: data,
                    columns: [
                        { "data": "Code", "className": 'Id_Puesto' },
                        { "data": "U_Puesto", "className": 'U_Puesto'  },
                        { "data": "U_Descripcion", "className": 'U_Descripcion'  },
                        {
                            "data": "validar",
                            render: function () { //data-toggle="modal" data-target="#modal-default" 
                                return '<button type="button" id="btnEditar" class="btn btn-default btnEditar" data-toggle="modal" data-target="#modal-default" >Editar</button>';
                            }
                        }
                    ],
                    error: function (error) {
                        alert("A ocurrido un error:" + error);
                    }
                });
            },
            error: function (error) {
                alert("Error en AJAX: " + error);
            },
        });


        
    }

   
    //Activa el Modal Editar
    $(document).on("click", ".btnEditar", function () {

        var id = $(this).closest("tr").find(".Id_Puesto").text();
        var puesto = $(this).closest("tr").find(".U_Puesto").text();
        var descripcion = $(this).closest("tr").find(".U_Descripcion").text();

        $("#idPuestoModal").val(id);
        $("#codPuestoModal").val(puesto);
        $("#nomPuestoModal").val(descripcion);

    });

    //Actualiza en SAP
    $(document).on("click", "#btnActualiza", function () {

  
      //  $("#btnActualiza").click(function () {
                //alert("");  
        var std = {};
        std.Code = $("#idPuestoModal").val();
        std.U_Puesto = $("#codPuestoModal").val();
        std.U_Descripcion = $("#nomPuestoModal").val();

        console.log(JSON.stringify(std));

        $.ajax({
            type: "POST",
            url: '/Configuracion/EditPuesto',
            data: JSON.stringify(std),//'{std: ' + JSON.stringify(std) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                toastr.info('Se ha registrado exitosamente')
                window.setTimeout(function () {
                    location.reload();
                }, 3000);
                
                //LoadData();
            },
            error: function () {
                toastr.error('Error al actualizar el registro')
                window.setTimeout(function () {
                    location.reload();
                }, 3000);
               
            }
         });
                return false;
            //});


      
    });

    //Guarda registros en SAP 
    $(document).on("click", "#btnGuardar", function () {


       
        var std = {};
       // std.Code = $("#idPuesto").val();
        std.U_Puesto = $("#codPuesto").val();
        std.U_Descripcion = $("#nomPuesto").val();

        console.log(JSON.stringify(std));

        $.ajax({
            type: "POST",
            url: '/Configuracion/CreatePuesto',
            data: JSON.stringify(std),//'{std: ' + JSON.stringify(std) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                toastr.success('Se ha registrado exitosamente')
                window.setTimeout(function () {
                    location.reload();
                }, 3000);
                
            },
            error: function () {
                toastr.error('Error al insertar el registro')
                window.setTimeout(function () {
                    location.reload();
                }, 3000);
                
                //alert("Error while inserting data");
            }
        });
        return false;
        //});



    });



    

   
    

});