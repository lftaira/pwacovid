
define(['./template2.js', '../lib/showdown/showdown.js', './clientStorage2.js'],
    function (template, showdown, clientStorage) {

        var blogPostUrl = '/Home/GetInfoStates/';

        // function loadLatestBlogPosts() {
        //     fetch(blogPostUrl)
        //         .then(function (response) {
        //             return response.json();
        //         }).then(function (data) {
        //             template.appendBlogList(data);
        //         });
        // }

        function loadLatestBlogPosts() {
            loadData(blogPostUrl)
        }

        function loadBlogPost(link) {
            fetch(blogPostUrl + link)
                .then(function (response) {
                    return response.text();
                }).then(function (data) {
                    var converter = new showdown.Converter();
                    html = converter.makeHtml(data);
                    template.showBlogItem(html, link);
                    window.location = '#' + link;
                });
        }

        function fetchPromise(url) {
            return new Promise(function (resolve, reject) {
                fetch(url)
                    .then(function (response) {
                        return response.json();
                    }).then(function (data) {
                        clientStorage.addPosts(data)
                            .then(function () {
                                resolve('The connection is OK, showing latest results');
                            });
                    }).catch(function (e) {
                        resolve('No connection, showing offline results');
                    });
                setTimeout(function () {
                    resolve('The connection is hanging, showing offline results');
                }, 1000);
            });
        }

        function loadData(url) {
            fetchPromise(url)
                .then(function (status) {
                    $('#connection-status').html(status);
                    clientStorage.getPosts()
                        .then(function (posts) {
                            template.appendBlogList(posts);
                        })
                });
        }

        function setOldestBlogPostId(data) {
            var ids = data.map(item => item.Id);
            oldestBlogPostId = Math.min(...ids);
        }

        function loadMoreBlogPosts() {
            fetch(blogMorePostsUrl + oldestBlogPostId)
                .then(function (response) {
                    return response.json();
                }).then(function (data) {
                    console.log(data);
                    template.appendBlogList(data);
                    setOldestBlogPostId(data);
                });
        }


        return {
            GetInfoStates: loadLatestBlogPosts,
            loadBlogPost: loadBlogPost
        }
    });