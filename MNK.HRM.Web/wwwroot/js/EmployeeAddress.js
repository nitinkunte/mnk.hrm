
var editorAddress; // use a global for the submit and return data rendering in the examples
 
$(document).ready(function() {
    editorAddress = new $.fn.dataTable.Editor( {
        ajax: "../php/standalone.php",
        fields: [ {
                label: "Status:",
                name:  "enable",
                type:  'radio',
                options: [
                    { label: 'Enabled',  value: 'Enabled' },
                    { label: 'Disabled', value: 'Disabled' }
                ]
            }, {
                label: "Server IP address:",
                name:  "server-ip"
            }, {
                label:     "Polling period:",
                fieldInfo: "Input value is in seconds",
                name:      "poll-period"
            }, {
                name: "protocol", // `label` since `data-editor-label` is defined for this field
                type: "select",
                options: [
                    { label: 'TCP', value: 'TCP' },
                    { label: 'UDP', value: 'UDP' }
                ]
            }
        ]
    } );
 
    $('#edit').on( 'click', function () {
        editor
            .buttons( {
                label: "Save",
                fn: function () { this.submit(); }
            } )
            .edit();
    } );
} );