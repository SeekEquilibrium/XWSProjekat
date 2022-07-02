using AgentApp.Models;
using Common;

namespace AgentApp.Services
{
    public class CommentService
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            IEnumerable<Comment> comments = await _commentRepository.GetAllAsync();
            return comments;
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            Comment comment = await _commentRepository.GetAsync(comment => comment.Id.Equals(id));
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllByUser(Guid userId)
        {
            IEnumerable<Comment> comments = await _commentRepository.GetAllAsync(comment => comment.UserId.Equals(userId));
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetAllByCompany(Guid companyId)
        {
            IEnumerable<Comment> comments = await _commentRepository.GetAllAsync(comment => comment.CompanyId.Equals(companyId));
            return comments;
        }

        public async Task CreateComment(Comment comment)
        {
            await _commentRepository.CreateAsync(comment);
        }

        public async Task UpdateComment(Comment comment)
        {
            await _commentRepository.UpdateAsync(comment);
        }
    }
}