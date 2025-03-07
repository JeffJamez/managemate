using Microsoft.EntityFrameworkCore;

namespace Managemate.Models;

public class ManageMateDBConetxt : DbContext
{
    public ManageMateDBConetxt(DbContextOptions<ManageMateDBConetxt> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskToDo> TasksToDo { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentMember> DepartmentMembers { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<MeetingParticipant> MeetingParticipants { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<WorkLog> WorkLogs { get; set; }
    public DbSet<WorkSession> WorkSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<User>()
       .HasIndex(u => u.Email)
       .IsUnique();

        modelBuilder.Entity<TaskToDo>()
       .HasOne(t => t.Creator)
       .WithMany(u => u.CreatedTasks)
       .HasForeignKey(t => t.CreatedById)
       .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<UserTask>()
            .HasOne(ut => ut.AssignedEmployee)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(ut => ut.AssignedEmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserTask>()
            .HasOne(ut => ut.TasksToDo)
            .WithMany(t => t.AssignedUsers)
            .HasForeignKey(ut => ut.TaskId);

        modelBuilder.Entity<DepartmentMember>()
            .HasOne(dm => dm.User)
            .WithMany()
            .HasForeignKey(dm => dm.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DepartmentMember>()
            .HasOne(dm => dm.Department)
            .WithMany(d => d.Members)
            .HasForeignKey(dm => dm.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Meeting>()
            .HasOne(m => m.Owner)
            .WithMany(u => u.MeetingsCreated)
            .HasForeignKey(m => m.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Meeting>()
            .HasMany(m => m.Participants)
            .WithOne(mp => mp.Meeting)
            .HasForeignKey(mp => mp.MeetingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MeetingParticipant>()
            .HasOne(mp => mp.Participant)
            .WithMany(u => u.Meetings)
            .HasForeignKey(mp => mp.ParticipantId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkLog>()
            .HasOne(wl => wl.Employee)
            .WithMany(u => u.WorkLogs)
            .HasForeignKey(wl => wl.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkSession>()
                   .HasOne(ws => ws.WorkLog)
                   .WithMany(w => w.Sessions)
                   .HasForeignKey(ws => ws.WorkLogId)
                   .OnDelete(DeleteBehavior.Cascade);

    }

}
