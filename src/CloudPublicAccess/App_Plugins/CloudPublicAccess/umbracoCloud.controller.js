(function (){
    'use strict';
    
    function loader(eventsService, $compile, $rootScope){
        eventsService.on('app.ready', function (){
            insertCloudLink();
        });
        
        function insertCloudLink(){
            var headerActions = angular.element(document).find('.umb-app-header__actions');
            //console.log(headerActions);
            
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
                
                let item = document.createElement('li');
                item.dataset['element'] = "global-cloud-portal-link";
                item.className = 'umb-app-header__action';
                item.append(cloudButton);
                
                headerActions[0].prepend(item);
                $compile(item)($rootScope);
            }
        }
        
        function goToCloudPortal() {
            const cloudPortal = "https://s1.umbraco.io";
            window.open(cloudPortal, '_blank').focus();
        }
    }
    
    angular.module('umbraco').run(loader);
    
})();