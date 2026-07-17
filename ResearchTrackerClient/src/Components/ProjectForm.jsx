function ProjectForm({
    form,
    editingProjectId,
    isSubmitting,
    onInputChange,
    onSubmit,
    onCancel
}) {
    const isEditing = editingProjectId !== null;

    return (
        <section className="create-section">
            <h2>
                {isEditing
                    ? "Edit research project"
                    : "Add a research project"}
            </h2>

            <form className="project-form" onSubmit={onSubmit}>
                <label>
                    Title
                    <input
                        type="text"
                        name="title"
                        value={form.title}
                        onChange={onInputChange}
                        required
                    />
                </label>

                <label>
                    Researcher
                    <input
                        type="text"
                        name="researcherName"
                        value={form.researcherName}
                        onChange={onInputChange}
                        required
                    />
                </label>

                <label>
                    Status
                    <select
                        name="status"
                        value={form.status}
                        onChange={onInputChange}
                    >
                        <option value="Planning">Planning</option>
                        <option value="In Progress">In Progress</option>
                        <option value="In Review">In Review</option>
                        <option value="Completed">Completed</option>
                    </select>
                </label>

                <label>
                    Start date
                    <input
                        type="date"
                        name="startDate"
                        value={form.startDate}
                        onChange={onInputChange}
                        required
                    />
                </label>

                <label className="description-field">
                    Description
                    <textarea
                        name="description"
                        value={form.description}
                        onChange={onInputChange}
                        rows="4"
                    />
                </label>

                <div className="form-actions">
                    <button type="submit" disabled={isSubmitting}>
                        {isSubmitting
                            ? "Saving..."
                            : isEditing
                                ? "Save changes"
                                : "Create project"}
                    </button>

                    {isEditing && (
                        <button
                            type="button"
                            className="cancel-button"
                            onClick={onCancel}
                        >
                            Cancel
                        </button>
                    )}
                </div>
            </form>
        </section>
    );
}

export default ProjectForm;