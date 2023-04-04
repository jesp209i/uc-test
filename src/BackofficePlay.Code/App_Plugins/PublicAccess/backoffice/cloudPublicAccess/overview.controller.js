function CloudPublicAccessController($q, $http, umbRequestHelper, localizationService) {    
    vm = this;
    let baseApiUrl = "backoffice/api/CloudPublicAccess/";
    
    vm.pageTitle = 'Cloud Public Access';
    vm.data = {};
    function init() {
        localizationService.localize("treeHeaders_cloudpublicaccess").then(function (value) {
            vm.pageTitle = value;
            $scope.$emit("$changeTitle", value);
        });
        
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            vm.data = data;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudPublicAccessController);