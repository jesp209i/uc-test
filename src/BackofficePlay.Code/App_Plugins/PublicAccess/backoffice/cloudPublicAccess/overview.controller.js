// Umbraco.Cloud.PublicAcccessController
function CloudSecretsController($q, $http, umbRequestHelper, localizationService) {
    let vm = this;
    
    let baseApiUrl = "backoffice/api/CloudPublicAccess/";
    
    vm.page = {};
    vm.data = {};
    function init() {
        vm.loading = true;
        
        var promises = [];

        promises.push(localizationService.localize("treeHeaders_cloudPublicAccessGroup").then(function (value) {
            vm.page.name = value;
            $scope.$emit("$changeTitle", value);
        }));
        
        $q.all(promises).then(function(){
           vm.loading = false; 
        });
        
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "Get")
        ).then(function (data) {
            vm.data = data;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudSecretsController);