$('#clientes').removeAttr('disabled');
var base_url="http://localhost:12345/api/";

/*var sesion=sessionStorage.getItem("iduser");
console.log(window.location.href.toString().search("usuarios/login.html"))
if (sesion===null && window.location.href.toString().search("usuarios/login.html")==-1) {
  window.location="../admin-lte/usuarios/login.html";
}*/
/**
 * Funcion que redondea un entero.
 * @param {int} numero 
 */
function redondeoEntero(numero)
{
if (parseInt(numero)%5==0) {
  return parseInt(numero)+".00";
}
else{
 return redondeoEntero(numero+1);
}
}

/**
 * Metodo que formatea un numero en miles.
 * @param {string} v digitos a formatear
 */

function SeperadorMiles(v){     
    v=v.replace(/([^0-9\.]+)/g,''); 
    v=v.replace(/^[\.]/,''); 
    v=v.replace(/[\.][\.]/g,''); 
    v=v.replace(/\.(\d)(\d)(\d)/g,'.$1$2'); 
    v=v.replace(/\.(\d{1,2})\./g,'.$1'); 
    v = v.toString().split('').reverse().join('').replace(/(\d{3})/g,'$1,');    
    v = v.split('').reverse().join('').replace(/^[\,]/,''); 
    return v;  
 }  
 /**
  * Metodo que obtiene la moneda por defecto del sistema.
  */
 function Get_Moneda_Default(){
  
  return $.ajax({
    type: "get",
    url: base_url+'Configuracion/Get_Moneda_Default',
    dataType: "text"
  });
  }
  /**
   * Formatea un texto y le pone la moneda por fecto a dicho texto.
   */

 /**
  * Solo permite introducir numeros.
  * @param {event} e event
  */
function soloNumeros(e){
  var key = e.charCode;
    console.log(key);
    return key >= 48 && key <= 57|| key==46;
}

//Resolve conflict in jQuery UI tooltip with Bootstrap tooltip 




$(document).ready(function(){
  $('[data-toggle="tooltip"]').tooltip();
  $('input[type="number"]').keypress(function(){
    if (!soloNumeros(event)){
      event.preventDefault();}
  });

  //Notificacion de pago fija
  //notyf.error("Por favor realice el pago lo antes posible para evitar suspencion del sistema.", "Pago fuera de fecha");

});

document.addEventListener('readystatechange', event => { 
/*
  // When HTML/DOM elements are ready:
  if (event.target.readyState === "interactive") {   //does same as:  ..addEventListener("DOMContentLoaded"..
    console.log("1");
  }
*/
 
});

/**
 * Funcion que va al servidor por ajax con los parametros especificado.
 * @param {string} url la url del servidor.
 * @param {JSON} datos json de la data.
 * @param {string} tipo tipo de envio(POST/GET).
 * @param {string} tipo_data tipo de la devuelta (json,text,html etc..).
 * @param {string} text_swal Descripcion del swal.
 */
function AjaxServer(url,datos,tipo,tipo_data,text_swal="Procesando..."){
  
  return $.ajax({
    type: tipo,
    url: url,
    data: JSON.stringify(datos),
    contentType: "application/json",
    dataType: tipo_data,
    beforeSend:function(){
      swal({
    icon: "../img/loader.gif",
    text:text_swal,
    button: false,
    closeOnClickOutside: false
  });
    },
    success:function(){
      swal.close();
    }
  });
}
//Funcion que muestra una alerta cuando da un error inesperado
function ErrorInesperado(titulo="Error inesperado",descripcion="Ha ocurrido un error inesperado, intentelo más tarde o contáctese con el administrador."){
  swal(titulo, descripcion, "error");
}
//Ejemplo de como usar la funcion ajaxServer y error inesperado
/*var a=AjaxServer(base_url+"admyC/Facturacion/Reservaciones",{id_prefactura:"1"},'get','json').then(function(resp){
alert(resp);
}).fail(function(error){
  ErrorInesperado();
})*/

//Funcion que crea una alerta de confirmacion, devuelve un boolean
function Confirmacion(titulo,descripcion,icon,callback,dangerMode=false,button_positivo="Sí",button_negativo="No") {
  swal({
  title: titulo,
  text: descripcion,
  icon:icon,
  buttons: [button_negativo,button_positivo],
  dangerMode: dangerMode,
})
.then((resp) => {
  callback(resp);
});
  }

/**
 * Funcion que elimina datos de una tabla con los datos especificado del siguiente 
 * json datos{table:nombre_tabla_db,column:nombre_columna,filtro:filtro_de_lacolumna_especificada,Estado:4}
 * @param {JSON} datos Json de la data a enviar al servidor.
 * @param {string} titulo Titulo del swal.
 * @param {string} descripcion Descripcion del swal.
 * @param {boolean} recargar Si va a recargar o no, por defecto false que significa que se recargara la pagina.
 */
function EliminarDatosAlerta(datos,titulo,descripcion,recargar=false){
  var url_destino=window.location;

 Confirmacion(titulo,descripcion,"warning",function(resp){

    if(resp==true){

  AjaxServer(base_url+"Functions/CRUD",datos,"post","text").then(function(resp){
    if(resp==1)
    swal("Eliminado", "Registro eliminado con exito!!", "success");

    else
    ErrorInesperado();

    if(!recargar)
    window.location=url_destino;

  }).fail(function(error){
  ErrorInesperado();
})
}
  },true);
 

}

/**
 * Metodo que inserta datos a una tabla con los paramametros especificado.
 * @param {string} table La tabla que se le va a insertar los datos.
 * @param {string} formularioId El id del formulario para serializar los inputs,select etc.
 * @param {array} camposRequeridoId Array con los id de los elementos para que sea obligatorio llenarlos.
 * @param {boolean} recargar Si va a recargar o no, por defecto false que significa que se recargara la pagina.
 * @param {string} funcion Nombre de la funcion que se ejecutara en el servidor eje:Nombre_function.
 * @param {string} parametros Nombre del parametro que tendra la funcion anterior, si son mas de uno pues seria un string con coma eje: param1,param2..
 * @param {int} estado Identifica al servidor que accion hara, en este caso 1 es insertar.
 */
function InsertarDatos(table,formularioId,camposRequeridoId,recargar=false,funcion=false,parametros=false,estado=1) {
  var data_server='';
  var url_destino=window.location;
  if(CamposRequeridos(camposRequeridoId))
  {
    var data = $('#'+formularioId).serializeArray();
    data.push({name: 'table', value: table});
    data.push({name: 'Estado', value: estado});
    data.push({name: 'funcion', value: funcion});
    data.push({name: 'parametros', value: parametros});

  //  console.log(data);return false;
    return AjaxServer(base_url+"Functions/CRUD",data,"post","text").then(function(resp){

    
    if(resp!=0)
    swal("Agregar datos", "Datos insertado con exito!!", "success");

    else
    ErrorInesperado();

    if(!recargar)
    window.location=url_destino;
   return JSON.parse(Remove_CaracteresJson(resp));
     
  }).fail(function(error){
  ErrorInesperado();
  return error;
})
  }
  else
  swal("Advertencia","Llene los campos requeridos","warning");
  return false;
  }

  /**
   * Metodo que inserta datos a una tabla con los paramametros especificado.
   * 
   * @param {string} table La tabla que se le va a insertar los datos.
   * @param {string} formularioId El id del formulario para serializar los inputs,select etc.
   * @param {array} camposRequeridoId Array con los id de los elementos para que sea obligatorio llenarlos.
   * @param {string} filtro String del filtro que hiria en el where.
   * @param {boolean} recargar Si va a recargar o no, por defecto false que significa que se recargara la pagina.
   * @param {string} funcion Nombre de la funcion que se ejecutara en el servidor eje:Nombre_function.
   * @param {string} parametros Nombre del parametro que tendra la funcion anterior, si son mas de uno pues seria un string con coma eje: param1,param2..
   * @param {int} estado Identifica al servidor que accion hara, en este caso 2 es actualizar.
   */
  function ActualizarData(table,formularioId,camposRequeridoId,filtro,recargar=false,funcion=false,parametros=false,estado=2){
    var data_server='';
  var url_destino=window.location;
  if(CamposRequeridos(camposRequeridoId))
  {
    var data = $('#'+formularioId).serializeArray();
    data.push({name: 'Estado', value: estado});
    data.push({name: 'table', value: table});
    data.push({name: 'funcion', value: funcion});
    data.push({name: 'parametros', value: parametros});
    data.push({name: 'filtro', value: filtro});


    //console.log(data);return false;
    return AjaxServer(base_url+"Functions/CRUD",data,"post","text").then(function(resp){

    
    if(resp!=0)
    swal("Actualizar datos", "Datos actualizado con exito!!", "success");

    else
    ErrorInesperado();

    if(!recargar)
    {
      window.location=url_destino;
      return true;
    }
    else (recargar)
   return JSON.parse(Remove_CaracteresJson(resp));
     
  }).fail(function(error){
  ErrorInesperado();
  return error;
})
  }
  else
  swal("Advertencia","Llene los campos requeridos","warning");
  return false;
  }
  /**
   * Metodo que va al servidor a seleccionar datos con los campos especificados.
   * @param {string} tabla Nombre de la tabla de la db.
   * @param {string} columnas String de las columnas a filtrar.
   * @param {string} filtro Filtro de dicho query.
   * @param {boolean/string} funcion Nombre de la funcion que se encuentra en el back-end. Nota: Esta funcion debe estar declarada en el controlador con el mismo nombre que indica aqui y mismo parametros.
   * @param {boolean/string} paramametros Los parametros que llevara la funcion actual(separados por comas, ejem: 1,2,3..).
   */
  function SeleccionarDatos (tabla,columnas,filtro,funcion=false,paramametros=false) {  

  return  AjaxServer(base_url+"Functions/CRUD",{Estado:3,table:tabla,column:columnas,filtro:filtro,funcion:funcion,parametros:paramametros},"post","json","Seleccionando datos..").then(function(r){
    return r;
    }).fail(function(err){
      console.log(err);
    });
  }
  /**
   * Metodo que limpia los datos de un elemento, con el formulario especificado.
   * @param {string} formularioId El id del formulario.
   */
  function LimpiarInput (formularioId) { 
    var form=$('#'+formularioId);
    let arry = Array.from(form[0].elements);
    arry.forEach(function(t){

      if (t.name && t[0]==undefined) {
        $(t).val('');
      }
     });
   }
   /**
    * Limpia los datos de los elementos con una clase especificada.
    * @param {string} clase Nombre de la clase.
    */
function LimpiarInputForClass(clase){
  clase=document.getElementsByClassName(clase);
for (let index = 0; index < clase.length; index++) {
  clase[index].value='';
  
}
}
/**
 * Metodo que valida los campos vacio(si lo estan le pone los bordes rojos) con los parametros especificado.
 * @param {array} arrayId Array con los id de los campos a validar.
 * @param {string} formId Nombre del formulario a validar, en caso de que no quieras validar todos los input de un formulario.
 */
  function CamposRequeridos(arrayId,formId=null){
    var contador=0;
    if(arrayId!=null){
      arrayId.forEach(function(t){ 
      if($('#'+t).val()=="") 
      {
        $('#'+t).css('border','1px solid #a94442');
        contador++;
      } 
      else{
        $('#'+t).css('border','1px solid #d2d6de');
      }
    });
    }

    else{

    var form=$('#'+formId);
    let arry = Array.from(form[0].elements);
    arry.forEach(function(t){  
     if(t.value=='' && t.type=="text"){
      $(t).css('border','1px solid #a94442');
        contador++;
     }
     else{
      $(t).css('border','1px solid #d2d6de');
     }
    });
    }
    return (contador==0)?true:false;
  }

  /**
   * Llena un objecto a una tabla con los parametros especificados.
   * @param {string} tableId Id de la tabla a llenar datos.
   * @param {array} columns Array de las columnas que tendra la tabla.
   * @param {object} object Objecto o data que tendran las filas.
   * @param {array} acciones Array de las acciones[0]='delete',acciones[1]='update',acciones[2]='id unico del campo'. ejem:['delete','update','idmonedas']
   * @param {array} modal_form Array del formulario(en caso que haya), modal(en caso que haya) y metodo para la accion eliminar ejem:['formmonedas','Nomodal','EliminarMonedas']
   * @param {array} acciones_personalizada Array de acciones personalizadas, son varios string con las acciones que desee.
   */
  function FillTable(tableId,columns,object,acciones=null,modal_form=null,acciones_personalizada=null,inicializarDatatable=true){
    var html='';
    var contador_acciones_p=0;
    object.forEach(function(t){
      html+='<tr>';

      for(var i=0; i<columns.length; i++){
     html+='<td>'+t[columns[i]]+'</td>';
    
     //Verificando que sea la ultima columna para ponerle las acciones
     if(i+1==columns.length && acciones!=null && acciones_personalizada==null)
     {
       var modelo=JSON.stringify(t);
       html+="<td> <a title='Eliminar' data-id='"+t[acciones[2]]+"' onclick='"+modal_form[2]+"(event)' style='padding:5px; cursor:pointer; color:red;' class='fa fa-remove'></a> <a title='Editar'  data-modelo='"+modelo+"' data-id='"+t[acciones[2]]+"' data-modal="+modal_form[1]+" data-form="+modal_form[0]+" onclick='EditarData(event)'' style='padding:5px; cursor:pointer;'' class='fa fa-edit'></a></td>";
     }

     if(i+1==columns.length && acciones==null && acciones_personalizada!=null)
       html+=acciones_personalizada[contador_acciones_p];
      }

      html+='</tr>';
      contador_acciones_p++;
      });
      //Destruyendo el datatable
      
      if(inicializarDatatable)
      $('#'+tableId).DataTable()
    .destroy();
    
      //Agregando los datos
      
      $('#'+tableId+" tbody").html(html);

      //Inicialiando el datatable
      
      if(inicializarDatatable)
      $('#'+tableId).DataTable( {
        'paging'      : true,
      'lengthChange': true,
      'searching'   : true,
      'ordering'    : true,
      'info'        : true,
      'autoWidth'   : true,
      "pageLength": 100,
      language: {
        "decimal": "",
        "emptyTable": "No hay información",
        "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
        "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
        "infoFiltered": "(Filtrado de _MAX_ total entradas)",
        "infoPostFix": "",
        "thousands": ",",
        "lengthMenu": "Mostrar _MENU_ Entradas",
        "loadingRecords": "Cargando...",
        "processing": "Procesando...",
        "search": "Buscar:",
        "zeroRecords": "Sin resultados encontrados",
        "paginate": {
            "first": "Primero",
            "last": "Ultimo",
            "next": "Siguiente",
            "previous": "Anterior"
        }
      }
    } ); 
    return object;
  }


  /**
   * Funcion que rellena los datos a un formulario especifico. Tem encuenta que para que se llenen las columnas del objeto, deben
   * llamarse igual al atributo name de los elementos de la etiqueta form. Eje <input name='value'/> =objecto.value
   * @param {string} formularioId Nombre del formulario a rellenar
   * @param {object} objecto Objecto a llenar los campos.
   * @param {*} modal 
   */

  function FillData(formularioId,objecto,modal){
    var form=$('#'+formularioId);
    var modelo=JSON.parse(Remove_CaracteresJson(objecto));
    let arry = Array.from(form[0].elements);
    arry.forEach(function(t){  

     if(t.name){
       $(t).val(modelo[t.name]);

       var clase=t.className.split(' ');
       if(clase.length>0)
       {
         //Cuando sea un selectpicker
       var res = clase.any(function(a){
         return a =="selectpicker"
         }) ;

         if(res==true)
         $(t).val(modelo[t.name]).selectpicker('refresh');

       }
     }
     
    });
  }
  /**
   * Metodo que filtra un datatable.
   * @param {string} tablaId Id de la tabla a filtrar.
   * @param {array} val Array de las columnas a filtrar, deben estar organizado como en la tabla del html, ejemplo
   *  [value_column1,value_column2....].
   */
  function FiltrarTable(tablaId,val){
  // DataTable
  var table = $('#'+tablaId).DataTable();
 var contador=0;
 // Apply the search
 table.columns().every( function () {
     var that = this;
             that
                 .search(val[contador] ? '^'+val[contador]+'$' : '', true, false)
                 .draw();
   contador++;
 } );
}
/**
 * Metodo que llena datos a un selectpicker.
 * @param {string} selectId El id del select.
 * @param {object} obj La data que tendra el select.
 * @param {string} nombre_columna Nombre de la columna que tendra en text del option.
 * @param {boolean} agregar En caso que quieras agregar el html al select o no, por defecto es true que si lo agregara al select.
 * @param {string} id El nombre de la columna que va en el value del option por defecto es null.
 * @param {array} atributos Datos de los atributos el option por defecto es null.
 * @param {array} filtroId Array del filtro si quieres todos el objecto dejelo null sino pues ponga un filtro ejemplo filtroId[0]='Nombre de la columna que esta en el objecto, puede ser el id', filtro[1]='valor del filtro'
 */
function RellenarSelectPicker(selectId,obj,nombre_columna,agregar=true,id=null,atributos=null,filtroId=null) { 
var html='';
var value="";
var contador=0;
  obj.forEach(function(t){

    if(filtroId==null || filtroId[1]==t[filtroId[0]]){
      if(id!=null)
    value="value='"+t[id]+"'";

    if(atributos==null)
    {
      atributos= new Array();
      atributos[contador]='';
    }
    
    html+="<option "+atributos[contador]+" "+value+" >"+t[nombre_columna]+"</option>";
    contador++;
    }
    
  });

  if(agregar)
  $('#'+selectId).html(html).selectpicker("refresh");

  return html;
 }
 /**
  * Funcion que formatea la las celdas de una tabla, le pone a las celdas especificadas la clase currency y a las celdas que tienen
  * valores negativos lo pone en rojo.
  * @param {string} tablaId Id de la tabla a formatear.
  * @param {array} cells Array de las celdas a formatear(ojo lo hara en todas las filas,pero en la celdas especificada).
  */
 function FormatCurrency(tablaId,cells){
    var tabla= document.getElementById(tablaId),rIndex;
      for (var i = 0; i < tabla.rows.length; i++) {
             if(i>0){
                for (let index = 0; index < cells.length; index++) {

                    //Aplicandole el color a los negativos
                    if(parseFloat($(tabla.rows[i].cells[cells[index]]).text()) <0)
                    $(tabla.rows[i].cells[cells[index]]).css('color','red');
                    $(tabla.rows[i].cells[cells[index]]).attr('class','currency');
                }
             }
            }
}
/**
 * Metodo que devuelve el string de la clase de un icono con el parametro especificado
 * @param {string} tipo_archivo nombre del tipo de archivo, si es docx,txt,pdf etc..
 */
function Get_Icon_TypeFile (tipo_archivo) { 
  switch (tipo_archivo) {
    case 'docx':
    return 'fa fa-file-word-o';
    case 'txt':
    return 'fa fa-file-text-o';
    case 'png':
    return 'fa fa-file-image-o';
    case 'gif':
    return 'fa fa-file-image-o';
    case 'jpg':
    return 'fa fa-file-image-o';
    case 'pdf':
    return 'fa fa-file-pdf-o';
    case 'mp3':
    return 'fa fa-file-audio-o';
    case 'mp4':
    return 'fa fa-file-video-o';
    case 'xls':
    return 'fa fa-file-excel-o';
    case 'html':
    return 'fa fa-file-code-o';
    case 'pptx':
      return 'fa fa-file-powerpoint-o';
      case 'zip':
        return 'fa fa-file-zip-o';
        case 'rar':
        return 'fa fa-file-zip-o';
    default:
      return 'fa fa-question';
  }
 }
 /**
  * Funcion que descarga un archivo con la ruta especificada
  * @param {string} ruta url del archivo.
  */
 function DescargarFile(ruta){
  window.open(ruta, '_blank');
 }

 /**
  * Envia un html por post y lo exporta a excel.
  * @param {*} html 
  * @param {*} filename 
  */
 function SendHTML(html,filename){

   AjaxServer(base_url+"Functions/ExportHTML",{html:html,filename:filename},"post","html","Rederizando datos...")
   .then(function(resp){
  
    $('head').append( resp);
     
  }).fail(function(error){
  ErrorInesperado();
})
 }

 
 /**
       * Metodo que Formatea los datos que van para el grafico por meses.
       * Devuelve un objeto con los meses que estan disponibles en objeto el ventas y otro objeto con las columnas especificadas en el metodo.
       * 
       * @param {*object} ventas objeto con todos los datos.
       * @param {*array} arrayColumn Array de las columnas que desea poner.
       */
      function FormatDataOfgraphic(ventas,arrayColumn) { 

       /**
         * Inicializando variables
         */ 
        var meses=[];
        var MonthOfYears=['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];
        var dataset=[]
        let contador=0;
 
         //Agrupando las ventas por mes
         var groupVentasMonth = ventas.groupBy(function(t){ 
             return moment(t.Fecha,"YYYY/MM/DD").month();
         });
 
         var key=-1;
         groupVentasMonth.forEach(function(t){
             if(key!=t.key)
             {
                 meses[contador]=MonthOfYears[t.key];
                 key=t.key;
                 let tempSum=[];
                 
                 t.forEach(function(k){ 
                     if(moment(k.Fecha,"YYYY/MM/DD").month()==t.key)
                     {
                         //Recorriendo las columnas que introduzcan por parametros.
                         for (let index = 0; index < arrayColumn.length; index++) {
                          if(k[arrayColumn[index]])
                             tempSum.push({key:arrayColumn[index],value:parseFloat(k[arrayColumn[index]])});
                         }
                     }
                  });
                  
                  var groupData = tempSum.groupBy(function(j){ 
                    return j.key;
                });
                for (let index = 0; index < arrayColumn.length; index++) {
                    
                    let temp_dataset=0;
                    
                    groupData.forEach(element => {
                        if(element.key==arrayColumn[index]){
                            temp_dataset= element.sum(function(f){ return f.value});
                        }

                    });
                   dataset.push({key:arrayColumn[index],value:temp_dataset,mes:meses[contador]});
                }
                  
                 contador++;
             }
         });

         //Arreglando los datos a usarse en el gráfico correctamente.

         var array=[];
         for (let index = 0; index < arrayColumn.length; index++) {
           var element=dataset.where(function(t){return t.key==arrayColumn[index]}).select(function(t){ return t.value;});
           array[arrayColumn[index]]=element;
         }

         var meses_grafico=dataset.select(function(t){ return t.mes }).distinct();
         dataset=[];

         array["Meses"]=meses_grafico
         dataset=array;
         return dataset;
        }


function digitos_loteria(e){
  
  if(soloNumeros(e))
  {
  var value=e.target.value;

  if(value.length==2 || value.length==5){
     e.target.value+="-";
  }
  return true;
  }
  return false;
}

        /**
         * Metodo que devuelve un codigo aleatorio con la longitud especificada
         * @param {int} length longitud del codigo
         */
        function GenerarCodigoAleatorio(length){
          var result           = '';
          var characters       = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
          var charactersLength = characters.length;
          for ( var i = 0; i < length; i++ ) {
             result += characters.charAt(Math.floor(Math.random() * charactersLength));
          }
          return result;
        }
        function Copiar(string,info="Copiado"){
          const el = document.createElement('textarea');
        el.value = string;
        document.body.appendChild(el);
        el.select();
        document.execCommand('copy');
        document.body.removeChild(el);

        notyf.info(info)
      }
