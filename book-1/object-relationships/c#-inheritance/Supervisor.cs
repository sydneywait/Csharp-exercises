namespace c__inheritance
{
    class Supervisor : Employee
    {

        public Supervisor(string jobTitleParam) : base(jobTitleParam)
        {
        }


        public void assignMaintenanceRequest(Employee employeeParam, MaintenanceRequest requestParam){
            // A supervisor should be able to create a maintenance request and assign a maintenance request to an employee. When they assign a maintenance request, it should be added to that employee's list of assigned requests and alter the assignedEmployee property on the request itself.

            employeeParam.assignedRequests.Add(requestParam);
            requestParam.assignedEmployee=employeeParam;

        }
    }


}






