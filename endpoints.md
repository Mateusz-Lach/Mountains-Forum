# Documentation for endpoints
## Controllers

### Main
* [GET verb] GetAllCategories() --WORKING
* [GET verb] GetCategoryById(int id) --WORKING
* [POST verb] CreateCategory()
  
### Topic
* [GET verb] GetAllyById(int id) --WORKING
* [GET verb] GetAllyById(string categoryName) --WORKING
* [PUT verb] CreateById(int categoryId, CreateTopicDto dto)

## Services

### Main
* [GET verb] GetAllCategories()
* [GET verb] GetCategoryById(int id)
* [POST verb] CreateCategory(CreateCategoryDto)
  
### Topic
* [GET verb] GetAllyById(int id) - gets all topics in category with id provided
* [GET verb] GetAllyById(string categoryName) - gets all topics in category with name provided
* [PUT verb] CreateById(int categoryId, CreateTopicDto dto) - creates topic in category with id provided
