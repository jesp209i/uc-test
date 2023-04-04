// Umbraco.Cloud.PublicAcccessController
function CloudSecretsController($q, $http, umbRequestHelper, localizationService) {
    let vm = this;
    
    let baseApiUrl = "backoffice/api/CloudPublicAccess/";
    
    vm.pageTitle = 'Cloud Public Access';
    vm.data = {};
    function init() {
        
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            vm.data = data;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudSecretsController);