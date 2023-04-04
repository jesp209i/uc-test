// Umbraco.Cloud.PublicAcccessController
function CloudSecretsController($q, $http, umbRequestHelper, localizationService) {
    let vm = this;
    
    let baseApiUrl = "backoffice/UmbracoCloudSecrets/CloudSecrets/";
    
    vm.page = {};
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
            $http.get(baseApiUrl + "SecretKeys")
        ).then(function (data) {
            vm.data = data;
        });
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "KeyVaultName")
        ).then(function (keyVaultName) {
            vm.keyVaultName = keyVaultName;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudSecretsController);