﻿using Blog_implementation.Models;

namespace Blog_implementation.Service
{
    public interface IForumService
    {
        Forum GetbyId(int id);

        Task<IEnumerable<Forum>> GetAllPost();
        Task<Forum> GetPost(int id);
        void Create(Forum post);
        void DeletePost(int id);
        Task<Forum> Update(int id, Forum post);
    }
}
