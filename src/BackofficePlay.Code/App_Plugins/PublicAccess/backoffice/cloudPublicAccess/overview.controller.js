function CloudPublicAccessController($q, $http, umbRequestHelper, localizationService, $scope) {    
    let vm = this;
    let baseApiUrl = "backoffice/api/CloudPublicAccess/";
    vm.loading = true;
    vm.pageTitle = "";
    vm.data = {};
    function init() {
        localizationService.localize("treeHeaders_cloudPublicAccess", 'Cloud Public Access').then(function (value) {
            console.log(value);
            vm.pageTitle = value;
            $scope.$emit("$changeTitle", value);
        }, function(error){
            console.log(error);
        });
        
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            console.log(data);
            vm.data = data;
            vm.loading = false;
        }, function(error){
            console.log(error);
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudPublicAccessController);