(function (){
    'use strict';
    
    function loader(eventsService, $compile, $rootScope, $location, $http, umbRequestHelper){
        eventsService.on('app.ready', function (){
            umbRequestHelper.resourcePromise(
                $http.get("backoffice/api/UmbracoCloud/GetCloudEnvironmentSettings")
            ).then(function (data) {
                insertCloudLink(data.EnvironmentName, data.ProjectPortalLink);
            });
        });
        
        function insertCloudLink(environmentName, projectPortalLink){
            var headerActions = angular.element(document).find('.umb-app-header__actions');
            
            const runme = true;
            if (runme && headerActions !== null && headerActions.length === 1){

                let listItemCloudPortalLink = createProjectCloudPortalLinkListItem(projectPortalLink);
                headerActions[0].prepend(listItemCloudPortalLink);

                let listItemEnvironmentName = createEnvironmentNameListItem(environmentName);
                headerActions[0].prepend(listItemEnvironmentName);
                
                $compile(listItemCloudPortalLink)($rootScope);
            }
        }
        
        function createProjectCloudPortalLinkListItem(projectPortalLink){
            let umbIcon = document.createElement('umb-icon');
            umbIcon.setAttribute('icon', "icon-cloud");
            umbIcon.setAttribute('aria-hidden', 'true');
            umbIcon.className="umb-icon";

            let spanActionIcon = document.createElement('span');
            spanActionIcon.className = "umb-app-header__action-icon";
            spanActionIcon.append(umbIcon);

            let localize = document.createElement('localize');
            localize.setAttribute('key',"visuallyHiddenTexts_openCloudPortal");

            let spanSrOnly = document.createElement('span');
            spanSrOnly.className = "sr-only";
            spanSrOnly.append(localize, "...");

            let cloudButton = document.createElement('button');
            cloudButton.addEventListener("click", () => goToCloudPortal(projectPortalLink))
            cloudButton.title = "Cloud Portal";
            cloudButton.type = "button";
            cloudButton.className = "umb-app-header__button btn-reset";
            cloudButton.append(spanSrOnly, spanActionIcon);

            let listItem = document.createElement('li');
            listItem.dataset['element'] = "global-cloud-portal-link";
            listItem.className = 'umb-app-header__action';
            listItem.append(cloudButton);
            
            return listItem;
        }
        
        function createEnvironmentNameListItem(environmentName){
            const listItemProps = {
              innerText: environmentName,
              className: 'umb-app-header__action',
              style: {
                  fontWeight: "900",
                  color: "#CCC"
              },
              dataset: {
                  element: "global-environment-name"
              }
            };
            
            let listItemEnvironmentName = document.createElement('li');
            Object.assign(listItemEnvironmentName, listItemProps);
            
            console.log(listItemEnvironmentName);
            
            return listItemEnvironmentName;
        }
        
        function goToCloudPortal(projectPortalLink) {
            window.open(projectPortalLink, '_blank').focus();
        }
    }
    
    angular.module('umbraco').run(loader);
    
})();