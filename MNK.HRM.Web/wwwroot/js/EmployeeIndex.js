var editor; // use a global for the submit and return data rendering in the examples
var table;
var empId;

$(document).ready(function() {

//alert('hi');

    editor = new $.fn.dataTable.Editor( {
        ajax: "https://localhost:65201/api/employees/get",
        table: "#tbEmployees",
        fields: [ 
            {
                label: "NA:",
                name: "NA",
                type: "hidden"
            },
            {
                label: "Id:",
                name: "Id",
                type: "hidden"
            },
            {
                label: "Prefix:",
                name: "Prefix"
            },
            {
                label: "First name:",
                name: "FirstName"
            }, 
            {
                label: "Last Name:",
                name: "LastName"
            }, 
            {
                label: "Suffix:",
                name: "Suffix"
            },
            {
                label: "Employee Id:",
                name: "EmployeeId"
            }, 

            {
                label: "Date of Birth:",
                name: "DateOfBirth",
                type: "datetime" 
            }
        ]

    } );


 
    table = $('#tbEmployees').DataTable( {
        dom: "Bfrtip",
        ajax: "https://localhost:65201/api/employees/get",
        columns: [
            { data: "Id" },
            {
                data: null,
                defaultContent: '',
                className: 'select-checkbox',
                orderable: false
            },
            { data: "Prefix" },
            { data: "FirstName" },
            { data: "LastName" },
            { data: "Suffix" },
            { data: "EmployeeId" },
            { data: "DateOfBirth"}
        ],
         "columnDefs": [
            {
                "targets": [ 0 ],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [ 5 ],
                "visible": false
            }
        ],
        keys: {
            columns: ':not(:first-child)',
            editor:  editor,
            editOnFocus: false
        },

        //select: true,
        
        select: {
            style:    'os',
            selector: 'td:first-child',
        },


        buttons: [
            { extend: "create", editor: editor },
            { extend: "edit",   editor: editor },
            { extend: "remove", editor: editor }
        ]
    } );

//    $('#tbEmployees').on( 'click', 'tbody tr', function (e) {

//        alert('hi');
//        var data = table.row(this).data();
//        alert('You clicked on ' + data[1] + '\s row');


//        editor.inline( this, {
//            submit: 'allIfChanged'
//        });


//    });

    $('#tbEmployees tbody').on('click', 'tr', function () {

        if ( $(this).hasClass('selected') ) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }


        empId = table.row(this).data();
        //alert( 'You clicked on '+data.Id+'\'s row' );
        $('#employeeDetails').show();
    } );



} );


