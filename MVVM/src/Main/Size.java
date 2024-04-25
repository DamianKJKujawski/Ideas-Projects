package Main;


public class Size 
{
    private int width_;
    private int height_;

    public Size(int width, int height) 
    {
        this.width_ = width;
        this.height_ = height;
    }

    
    
    /* 
     * Getters and Setters: 
    */

    public int get_width() {
        return width_;
    }

    public void set_width(int width) {
        this.width_ = width;
    }

    public int get_height() {
        return height_;
    }

    public void set_height(int height) {
        this.height_ = height;
    }
}