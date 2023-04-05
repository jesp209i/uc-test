(function(){
    "use strict";

function CloudPublicAccessController($q, $http, umbRequestHelper, localizationService, $scope, $route) {    
    let vm = this;
    const baseApiUrl = "backoffice/api/CloudPublicAccess/";
    vm.pageTitle = '';
    vm.data = {};
    function init() {
        vm.loading = true;
        
        var redirection = $route.current.params.returnTo;
        if (redirection !== null){
            window.location.href = redirection;
        }
        console.log($route);

        let getTitle = localizationService.localize("treeHeaders_cloudPublicAccess", 'Cloud Public Access title').then(function (value) {
            vm.pageTitle = value;
            $scope.$emit("$changeTitle", value);
        });
        
        let getSettings = umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            vm.data = data;
            vm.loading = false;
        });

        $q.all([getTitle, getSettings]).then(function () {
            vm.loading = false;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudPublicAccessController);
})();