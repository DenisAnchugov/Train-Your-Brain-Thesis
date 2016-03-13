angular.module("trainBrain", ["ionic", "trainBrain.controllers", "trainBrain.services"])

.run(function ($ionicPlatform) {
    $ionicPlatform.ready(function () {
        if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
            //window.cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        }
        if (window.StatusBar) {
            window.StatusBar.styleLightContent();
        }
    });
})

.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider.state("main", {
        url: "/main",
        templateUrl: "templates/main-page.html",
        controller: "ExpressionController"
    });

    $urlRouterProvider.otherwise("/main");
});
