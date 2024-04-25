package Main;
public class Object2D 
{
    private String name_;
    protected Size size_;

    
    
    public Object2D(String name, Size size) 
    {
        this.name_ = name;
        this.size_ = size;
    }

    
    
    /* 
     * Getters and Setters: 
    */
    
    public String get_name() {
        return name_;
    }

    public void set_name(String name) {
        this.name_ = name;
    }

    // Getters and Setters for size
    public Size get_size() {
        return size_;
    }

    public void set_size(Size size) {
        this.size_ = size;
    }
}
