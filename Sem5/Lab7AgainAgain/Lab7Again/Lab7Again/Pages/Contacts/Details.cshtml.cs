﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab7Again.Data;
using Lab7Again.Models;
using Lab7Again.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Lab7Again.Pages.Contacts
{
    public class DetailsModel : DI_BasePageModel
    {
        private readonly Lab7Again.Data.Lab7AgainContext _context;

        public DetailsModel(
        Lab7AgainContext context,
        IAuthorizationService authorizationService,
        UserManager<AppUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }


        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact? _contact = await Context.Contact.FirstOrDefaultAsync(m => m.ContactId == id);

            if (_contact == null)
            {
                return NotFound();
            }
            Contact = _contact;

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Contact.OwnerID
                && Contact.Status != ContactStatus.Approved)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, ContactStatus status)
        {
            var contact = await Context.Contact.FirstOrDefaultAsync(
                                                      m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var contactOperation = (status == ContactStatus.Approved)
                                                       ? ContactOperations.Approve
                                                       : ContactOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, contact,
                                        contactOperation);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            contact.Status = status;
            Context.Contact.Update(contact);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
