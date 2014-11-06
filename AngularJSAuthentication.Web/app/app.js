var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {
	$routeProvider.when("/home", {
		controller: "homeController",
		templateUrl: "/app/views/home.html"
	});
	
	$routeProvider.when("/login", {
		controller: "loginController",
		templateUrl: "/app/views/login.html"
	});
	
	$routeProvider.when("/signup", {
		controller: "signupController",
		templateUrl: "/app/views/signup.html"
	});

	$routeProvider.when("/books", {
		controller: "booksController",
		templateUrl: "/app/views/books.html"
	});

	$routeProvider.when("/book", {
		controller: "booksController",
		templateUrl: "/app/views/newBook.html"
	});

	$routeProvider.otherwise({ redirectTo: "/home" });
});

//var serviceBase = 'http://localhost:58114/';
var serviceBase = 'http://centricconnectdev.azurewebsites.net//';
app.constant('ngAuthSettings', {
	apiServiceBaseUri: serviceBase,
	clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
	$httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
	authService.fillAuthData();
}]);