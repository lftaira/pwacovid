define([], function () {
    function generateBlogItem(item) {
        var template = $('#blog-card').html();
        template = template.replace('{{State}}', item.state);
        template = template.replace('{{Cases}}', item.cases);
        template = template.replace('{{Deaths}}', item.deaths);
        template = template.replace('{{Suspects}}', item.suspects);
     return template;
    }

    function appendBlogList(items) {
     var cardHtml = '';
     for (var i = 0; i < items.data.length; i++) {
     cardHtml += generateBlogItem(items.data[i]);

    }
    $('.blog-list').append(cardHtml);
   }
   return {
    appendBlogList: appendBlogList
    // showBlogItem: showBlogItem
   }
   });