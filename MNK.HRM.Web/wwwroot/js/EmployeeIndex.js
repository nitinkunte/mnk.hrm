var editor; // use a global for the submit and return data rendering in the examples


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
//         formOptions: {
//                inline: {
//                    onBlur: 'submit'
//                }
//            }
    } );

    $('#tbEmployees').on( 'click', 'tbody td', function (e) {
        editor.inline( this, {
            submit: 'allIfChanged'
        });
    });
 
    $('#tbEmployees').DataTable( {
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
            editOnFocus: true
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
} );


