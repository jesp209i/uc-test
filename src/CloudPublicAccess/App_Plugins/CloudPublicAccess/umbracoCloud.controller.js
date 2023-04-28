(function (){
    'use strict';
    
    function loader(eventsService, $compile, $rootScope, $location){
        eventsService.on('app.ready', function (){
            insertCloudLink();
        });
        
        function insertCloudLink(){
            var headerActions = angular.element(document).find('.umb-app-header__actions');
            console.log($location);
            
            const runme = true;
            
            if (runme && headerActions !== null && headerActions.length === 1){
                
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
                cloudButton.addEventListener("click", goToCloudPortal)
                cloudButton.title = "Cloud Portal";
                cloudButton.type = "button";
                cloudButton.className = "umb-app-header__button btn-reset";
                cloudButton.append(spanSrOnly, spanActionIcon);
                
                let listItem = document.createElement('li');
                listItem.dataset['element'] = "global-cloud-portal-link";
                listItem.className = 'umb-app-header__action';
                listItem.append(cloudButton);

                let listItemEnvironmentName = document.createElement('li');
                listItemEnvironmentName.dataset['element'] = "global-environment-name";
                listItemEnvironmentName.className = 'umb-app-header__action';
                listItemEnvironmentName.style.fontWeight = "900";
                listItemEnvironmentName.style.color = "#CCC";
                listItemEnvironmentName.innerText = getEnvironment();

                
                headerActions[0].prepend(listItem);
                headerActions[0].prepend(listItemEnvironmentName);
                $compile(listItem)($rootScope);
            }
        }
        
        function goToCloudPortal() {
            const cloudPortal = "https://s1.umbraco.io";
            window.open(cloudPortal, '_blank').focus();
        }

        function getEnvironment(){
            const absUrl = $location.absUrl();
            if (absUrl.includes("://localhost:"))
                return "local";
            if (absUrl.includes("://dev-"))
                return "development";
            if (absUrl.includes("://stage-"))
                return "staging";

            return "live";
        }
    }
    
    angular.module('umbraco').run(loader);
    
})();