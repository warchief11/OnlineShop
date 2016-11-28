(function () {
    'use Strict';

    var app = angular.module('shopApp', ['ui.router', 'ngAnimate']);

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider
             .state("dashboard", {
                 url: "/",
                 templateUrl: 'Apps/templates/dashboard.html',
                 controller: 'DashboardCtrl as vm'
             })
             .state('checkout', {
                 url: '/checkout',
                 templateUrl: 'Apps/templates/checkout.html',
                 controller: 'CheckoutCtrl as vm',
             })
            .state('orderComplete', {
                url: '/order',
                templateUrl: 'Apps/templates/orderComplete.html'
            })
             .state('about', {
                url: '/about',
                templateUrl: 'Apps/templates/about.html',
             });
    }]);

    //uncomment these lines for troubleshooting
    //app.run(function ($rootScope) {
    //    var $rootScope = angular.element(document.querySelectorAll("[ui-view]")[0]).injector().get('$rootScope');

    //    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
    //        console.log('$stateChangeStart to ' + toState.to + '- fired when the transition begins. toState,toParams : \n', toState, toParams);
    //    });

    //    $rootScope.$on('$stateChangeError', function (event, toState, toParams, fromState, fromParams) {
    //        console.log('$stateChangeError - fired when an error occurs during transition.');
    //        console.log(arguments);
    //    });

    //    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
    //        console.log('$stateChangeSuccess to ' + toState.name + '- fired once the state transition is complete.');
    //    });

    //    $rootScope.$on('$viewContentLoaded', function (event) {
    //        console.log('$viewContentLoaded - fired after dom rendered', event);
    //    });

    //    $rootScope.$on('$stateNotFound', function (event, unfoundState, fromState, fromParams) {
    //        console.log('$stateNotFound ' + unfoundState.to + '  - fired when a state cannot be found by its name.');
    //        console.log(unfoundState, fromState, fromParams);
    //    });
    //});
}());