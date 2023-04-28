(function (){
    'use strict';
    
    function loader(eventsService){
        eventsService.on('app.ready', function (){
            insertCloudLink();
        });
        
        function insertCloudLink(){
            console.log("Hej");
        }
    }
    
    angular.module('umbraco').run(loader);
    
})();