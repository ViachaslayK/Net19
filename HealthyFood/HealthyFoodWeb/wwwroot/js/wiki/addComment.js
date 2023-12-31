﻿$(document).ready(function () {

    $('.add-comment').click(function (e) {
        const userText = $(e.target).parent().parent().find('[name=newComment]').val();
        const blockId = $(e.target).parent().parent().find('[name=blockId]').val();
        const user = $(e.target).parent().parent().find('[name=author]').val();
        
        $.get(`/api/wiki/AddComment?comment=${userText}&blockId=${blockId}`)
            .then(function (commentId) {
                const commentDiv = `
                    <div class="comment-block">
                                <div class="comments">
                                    <span class="comment-text">
                                        ${userText}
                                    </span>
                                    <span class="authorComments">
                                        ${user}
                                    </span>
                                </div>
                                    <form action="/Wiki/RemoveComment" class="remove-form">
                                        <input type="hidden" value="${commentId}" name="commentId">
                                        <input type="submit" value="Delete Comment" class="delete-comment-button">
                                    </form>
                                    <a class="update-link" href="/wiki/UpdateComment/${commentId}">update</a>
                            </div>
                `;
                const containerComment = $(e.target).parent().parent().parent().prev()

                containerComment.append(commentDiv);
            });

        $("[name=newComment]").val('');
    });

    $('.delete-block-btn').on('click', function (e) {
        e.preventDefault();

        const block = $(this).closest('.block');

        const blockId = $(this)

            .closest('.removeBlock')
            .find('[name=blockId]')
            .val();

        $.get(`/api/wiki/Remove?blockId=${blockId}`);

        block.remove();
    });

    $(document).on('click', '.delete-comment-button', DeletComment);

    function DeletComment(e) {
        e.preventDefault();

        const commentId = $(this)
            .closest('.remove-form')
            .find('[name=commentId]')
            .val();

        $.get(`/api/wiki/removeComment?id=${commentId}`);

        $(this).closest('.comment-block').remove();
    }
});