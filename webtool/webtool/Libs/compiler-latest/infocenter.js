/// <reference path="../_references.js" />

define(["jquery", "base", "api", "jsrender"], function ($, base, api) {
    var pageSize = 10;
    // init
    getTopicList();

    var havNextPage = true;
    var firstLoad = true;
    var $blank = $(".infocenter-blank");
    var $topicWrap = $(".infocenter-topic");

    // jsrender
    $.views.helpers({
        getLoginHeadUrl: function () {
            var url = $("#loginHeadUrl").val();
            return url;
        }
    });

    function getTopicList() {
        var totalSize = $(".J_topicItem").length;
        api.getTopicList(pageSize, totalSize, function (list) {
            if (list && list.length) {
                if (firstLoad) {
                    $topicWrap.show();
                }
                for (var i = 0, len = list.length; i < len; i++) {
                    var item = list[i];
                    if (item.replyList) {
                        for (var j = 0; j < item.replyList.length; j++) {
                            var reply = item.replyList[j];
                            reply.isMyShelf = item.isMyShelf;
                        }
                    }
                }
                var html = $("#topicItemTmpl").render(list);
                $("#topicListWrap").append(html);

                base.widget.wordStat.init();
            }
            else {
                havNextPage = false;
                if (firstLoad) {
                    $blank.show();
                }
                else {
                    $("#btnGetMoreTopic").text("已加载全部数据");
                }
            }

            firstLoad = false;
        });
    }

    // bind event 
    // 加载更多话题
    $("#btnGetMoreTopic").click(function () {
        if (havNextPage) {
            getTopicList();
        }
        return false;
    });

    // 发布话题
    $("#btnPublish").click(function () {
        var $topicInput = $("#topicInput");
        var content = $("#topicInput").val();
        if (!content) {
            base.tipInfo("说点什么吧");
            return false;
        }
        if (content.length > 240) {
            base.tipInfo("请输入240字以内");
            return false;
        }

        api.publishTopic(content, function (topic) {
            base.tip("发布成功", function () {
                if (!havNextPage) {
                    $blank.hide();
                    $topicWrap.show();
                }
                var $html = $($("#topicItemTmpl").render(topic));
                $html.css("opacity", 0);
                $("#topicListWrap").prepend($html);
                $html.animate({ opacity: 1 }, "slow");
                $topicInput.val("").focusout();
                base.widget.data.wordStat[0].reset();

                // add word stat fn
                base.widget.wordStat.init();
            });
        });
    });

    // 删除话题
    $("#topicListWrap").on("click", ".deleteTopic", function () {
        var $this = $(this);
        base.confirm("确认要删除这条话题吗？", function () {
            var $parent = $this.closest(".J_topicItem");
            var id = $parent.data("topicId");
            api.deleteTopic(id, function () {
                base.tip("删除成功", function () {
                    $parent.animate({ height: 0, width: 0, opacity: 0 }, "slow", function () {
                        $parent.remove();
                    });
                });
            });
        })
    });

    // 回复评论
    $("#topicListWrap").on("click", ".J_replyButton", function () {
        var $this = $(this);
        var $replybox = $this.closest(".J_replybox");
        var $text = $replybox.find(".J_replytextarea");
        var $parent = $this.closest(".J_topicItem")
        var topicId = $parent.data("topicId");
        var userId = $parent.data("userId");
        var comment = $text.val();
        if (!comment) {
            base.tipInfo("说点什么吧");
            return false;
        }
        if (comment.length > 240) {
            base.tipInfo("请输入240字以内");
            return false;
        }
        api.replyTopic($text.val(), topicId, userId, null, function (reply) {
            base.tip("评论成功", function () {
                reply.isMyShelf = $parent.data("ismyself");
                $this.closest(".J_replyWrap").find("ul")
                    .append($("#replyItemTmpl").render(reply));
                toggleReplyBox("hide", $this.closest(".J_replybox"));
                $text.val("").focusout();

                base.widget.data.wordStat[$parent.index() + 1].reset();
            });
        });
    });

    // 删除回复
    $("#topicListWrap").on("click", ".J_deleteReply", function () {
        var $this = $(this);
        base.confirm("确认删除回复吗？", function () {
            var replyId = $this.data("replyId");
            api.deleteReply(replyId, function () {
                base.tip("删除回复成功", function () {
                    var $li = $this.closest("li");
                    $li.remove();
                });
            });
        });
    });

    // 展开隐藏评论区域
    $("#topicListWrap").on("click", ".J_replyboxtip", function () {
        var $this = $(this);
        toggleReplyBox("show", $this.closest(".J_replybox"));
    });
    $("#topicListWrap").on("click", ".J_replyCancleButton", function () {
        var $this = $(this);
        toggleReplyBox("hide", $this.closest(".J_replybox"));
    });
    function toggleReplyBox(status, $replyWrap) {
        var $replytip = $replyWrap.find(".J_replyboxtip");
        var $replytext = $replyWrap.find(".J_replyboxtext");
        if (status === "show") {
            $replytip.hide();
            $replytext.show();
            $replytext.find("textarea").focus();
        }
        else {
            $replytip.show();
            $replytext.hide();
        }
    }
});