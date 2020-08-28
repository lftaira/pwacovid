// define([], function () {
//     var blogPostUrl = '/Home/GetInfoStates/';
//     function loadLatestBlogPosts() {
//     fetch(blogPostUrl)
//     .then(function (response) {
//     return response.json();
//     }).then(function (data) {
//     console.log(data);
//     });
//     }
//     return { GetInfoStates :
//         loadLatestBlogPosts
//          }
//         });

        define(['./template2.js'], function (template) {
            var blogPostUrl = '/Home/GetInfoStates/';
            function loadLatestBlogPosts() {
             fetch(blogPostUrl)
                .then(function (response) {
                return response.json();
             }).then(function (data) {
             template.appendBlogList(data);
             });
            }
            return {
                GetInfoStates : loadLatestBlogPosts
            }
            });